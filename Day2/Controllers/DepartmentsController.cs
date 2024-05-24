using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore.Annotations;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Day2.DTO;
using Day2.Models;
using Day2.Repository;

namespace Day2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentsController : ControllerBase
    {
        //private readonly ITIContext _context;
       GenricRepository<Department> Repo;

        public DepartmentsController(GenricRepository<Department> Repo)
        {
          this.Repo = Repo;
        }

        // GET: api/Departments
        [HttpGet]
        [SwaggerOperation(
            Summary = "Get All Departments",
            Description = "Retrieve all departments with the number of associated students.",
            OperationId = "GetDepartments"
        )]
        [SwaggerResponse(200, "Success", typeof(IEnumerable<departmentDTO>))]
        [SwaggerResponse(404, "Not Found")]
        public  ActionResult<IEnumerable<departmentDTO>> GetDepartments()
        {
            var departments =  Repo.GetAll().Select(d => new departmentDTO
            {
                Dept_Id = d.Dept_Id,
                Dept_Name = d.Dept_Name,
                Dept_Location = d.Dept_Location,
                Dept_Manager = d.Dept_Manager,
                Dept_Desc = d.Dept_Desc,
                StudentCount = d.Students.Count
            }).ToList();

            return Ok(departments);
        }

        // GET: api/Departments/5
        [HttpGet("{id}", Name = "GetDepartment")]
        [SwaggerOperation(
            Summary = "Get Department By Id",
            Description = "Retrieve a department by its ID.",
            OperationId = "GetDepartment"
        )]
        [SwaggerResponse(200, "Success", typeof(Department))]
        [SwaggerResponse(404, "Not Found")]
        public  ActionResult<Department> Department(int id)
        {
            var department =  Repo.GetById(id);

            if (department == null)
            {
                return NotFound();
            }

            return department;
        }

        // PUT: api/Departments/5
        [HttpPut("{id}")]
        [SwaggerOperation(
            Summary = "Update Department",
            Description = "Update an existing department by ID.",
            OperationId = "PutDepartment"
        )]
        [SwaggerResponse(204, "No Content")]
        [SwaggerResponse(400, "Bad Request")]
        public  IActionResult PutDepartment(int id, Department department)
        {
            if (id != department.Dept_Id)
            {
                return BadRequest();
            }
            try
            {
               Repo.Update(department);
                Repo.Save();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DepartmentExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Departments
        [HttpPost]
        [SwaggerOperation(
            Summary = "Add Department",
            Description = "Create a new department.",
            OperationId = "PostDepartment"
        )]
        [SwaggerResponse(201, "Created Department", typeof(void))]
        [SwaggerResponse(400, "Bad Request")]
        public ActionResult<Department> PostDepartment(Department department)
        {
 
            
                if (DepartmentExists(department.Dept_Id))
                {
                    return Conflict();
                }
                Repo.Add(department);
                Repo.Save();
            

            return CreatedAtAction("GetDepartment", new { id = department.Dept_Id }, department);
        }

        // DELETE: api/Departments/5
        [HttpDelete("{id}")]
        [SwaggerOperation(
            Summary = "Delete Department",
            Description = "Delete a department by its ID.",
            OperationId = "DeleteDepartment"
        )]
        [SwaggerResponse(204, "No Content")]
        [SwaggerResponse(404, "Not Found")]
        public  IActionResult DeleteDepartment(int id)
        {
            var department =  Repo.GetById(id);
            if (department == null)
            {
                return NotFound();
            }

             Repo.Delete(id);
             Repo.Save();

            return NoContent();
        }

        private bool DepartmentExists(int id)
        {
            return Repo.GetById(id) != null;
        }
    }
}
