using Day2.DTO;
using Day2.Models;
using Day2.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Day2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        //   private readonly ITIContext _context;
        IStudentRepository Repo;

        public StudentsController(IStudentRepository Repo)
        {
            this.Repo = Repo;
        }
        /// <summary>
        /// Return all Student And Can search For Spesific Student And Pagination 
        /// </summary>
        /// <param name="PageNumber"></param>
        /// <param name="PageSize"></param>
        /// <param name="name"></param>
        /// <returns>
        /// and the return student data id , name , address,super,age</returns>
        // GET: api/Students
        [HttpGet]
        public async Task<ActionResult<IEnumerable<studentDTO>>> GetStudents(int PageNumber = 1, int PageSize = 30, string name = null)
        {
            var totalCount = Repo.GetAllStudents().Count();
            List<studentDTO> students = new List<studentDTO>();
            var totalPages = (int)Math.Ceiling(totalCount / (double)PageSize);
            if (name == null)
            {
                students = Repo.GetAllStudents().Skip((PageNumber - 1) * PageSize)
                   .Take(PageSize)
                   .Select(s => new studentDTO
                   {
                       St_Id = s.St_Id,
                       St_Fname = s.St_Fname,
                       St_Lname = s.St_Lname,
                       St_Address = s.St_Address,
                       St_super = s.St_superNavigation?.St_Fname,
                       Dept_Id = s.Dept_Id,
                       St_Age = s.St_Age
                   })
                   .ToList();

            }
            else
            {
                students = Repo.GetAllStudents()
                .Where(s => s.St_Fname != null && s.St_Fname.Contains(name))
                .Select(s => new studentDTO
               {
                    St_Id = s.St_Id,
                     St_Fname = s.St_Fname,
                     St_Lname = s.St_Lname,
                     St_Address = s.St_Address,
                     St_super = s.St_superNavigation?.St_Fname,
                     Dept_Id = s.Dept_Id,
                     St_Age = s.St_Age
               })
                .ToList();
            }


            return Ok(students);


        }
        // GET: api/Students/5
        [HttpGet("{id}")]
        public ActionResult<Student> GetStudent(int id)
        {
            var student = Repo.GetStudentById(id); 

            if (student == null)
            {
                return NotFound();
            }

            return student;
        }


        // PUT: api/Students/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public IActionResult PutStudent(int id, Student student)
        {
            if (id != student.St_Id)
            {
                return BadRequest();
            }

            try
            {
                Repo.UpdateStudent(student);
                Repo.Save();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudentExists(id))
                {
                    return NotFound();
                }
                else
                {
                    return Conflict();
                }
            }

            return NoContent();
        }


        // POST: api/Students
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Consumes("application/json")]
        [Produces("application/json")]

        public ActionResult<Student> PostStudent(Student student)
        {
            if (StudentExists(student.St_Id))
            {
                return Conflict(); 
            }

            Repo.AddStudent(student);
            Repo.Save();
            return CreatedAtAction("GetStudent", new { id = student.St_Id }, student);
        }


        //public IActionResult PostStudent(Student student)
        //{
        //    Repo.AddStudent(student);
        //    return CreatedAtAction("GetStudent", new { id = student.St_Id }, student);
        //}

        
        // DELETE: api/Students/5
        [HttpDelete("{id}")]
        public IActionResult DeleteStudent(int id)
        {
            var student = Repo.GetStudentById(id);
            if (student == null)
            {
                return NotFound();
            }
            Repo.DeleteStudent(id);
            Repo.Save();

            return NoContent();
        }

        private bool StudentExists(int id)
        {
            return Repo.GetStudentById(id) != null;
        }
    }
}
