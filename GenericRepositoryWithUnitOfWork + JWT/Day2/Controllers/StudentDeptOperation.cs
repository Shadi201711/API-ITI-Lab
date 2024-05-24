using Day2.Models;
using Day2.UnitOfWork;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Day2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentDeptOperation : ControllerBase
    {
        Unit MyUnit;
        public StudentDeptOperation(Unit MyUnit)
        {
            this.MyUnit = MyUnit;
        }
     
        [HttpPost]
        [Route("AddStudent")]
        public IActionResult AddStudent(Student student)
        {
            MyUnit.StudentRepository.Add(student);
            MyUnit.DepartmentRepository.Add(student.Dept);
            MyUnit.Save();
            //MyUnit.DepartmentRepository.Save();
            //MyUnit.StudentRepository.Save();
            return Ok();
        }
        [HttpPut]
        [Route("UpdateStudent")]
        public IActionResult UpdateStudent(Student student)
        {
            MyUnit.DepartmentRepository.Update(student.Dept);
            MyUnit.StudentRepository.Update(student);
             MyUnit.Save();
           //MyUnit.DepartmentRepository.Save();
           //MyUnit.StudentRepository.Save();
            return Ok();
        }
       
    }
}
