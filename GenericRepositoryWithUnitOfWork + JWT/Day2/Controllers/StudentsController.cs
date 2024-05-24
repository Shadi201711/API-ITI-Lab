using Day2.DTO;
using Day2.Models;
using Day2.Repository;
using Day2.UnitOfWork;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Day2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly Unit _UN;

        public StudentsController(Unit UN)
        {
            _UN = UN ?? throw new ArgumentNullException(nameof(UN));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<studentDTO>>> GetStudents(int PageNumber = 1, int PageSize = 30, string name = null)
        {
            var totalCount = _UN.StudentRepository.GetAll().Count();
            List<studentDTO> students = new List<studentDTO>();
            var totalPages = (int)Math.Ceiling(totalCount / (double)PageSize);

            if (name == null)
            {
                students = _UN.StudentRepository.GetAll().Skip((PageNumber - 1) * PageSize)
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
                students = _UN.StudentRepository.GetAll()
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

        [HttpGet("{id}")]
        public ActionResult<Student> GetStudent(int id)
        {
            var student = _UN.StudentRepository.GetById(id);

            if (student == null)
            {
                return NotFound();
            }

            return student;
        }

        [HttpPut("{id}")]
        public IActionResult PutStudent(int id, Student student)
        {
            if (id != student.St_Id)
            {
                return BadRequest();
            }

            try
            {
                _UN.StudentRepository.Update(student);
                _UN.Save();
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

        [HttpPost]
        [Consumes("application/json")]
        [Produces("application/json")]
        public ActionResult<Student> PostStudent(Student student)
        {
            if (StudentExists(student.St_Id))
            {
                return Conflict();
            }

            _UN.StudentRepository.Add(student);
            _UN.Save();
            return CreatedAtAction("GetStudent", new { id = student.St_Id }, student);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteStudent(int id)
        {
            var student = _UN.StudentRepository.GetById(id);
            if (student == null)
            {
                return NotFound();
            }
            _UN.StudentRepository.Delete(id);
            _UN.Save();

            return NoContent();
        }

        private bool StudentExists(int id)
        {
            return _UN.StudentRepository.GetById(id) != null;
        }
    }
}
