using Day2.Models;
using Microsoft.EntityFrameworkCore;

namespace Day2.Repository
{
   public interface IStudentRepository
    {
        public IEnumerable<Student> GetAllStudents();
   
        public Student GetStudentById(int id);
     
        public void AddStudent(Student student);
       
        public void UpdateStudent(Student student);
     
        public void DeleteStudent(int id);
       
        public void Save();
      

    }
}
