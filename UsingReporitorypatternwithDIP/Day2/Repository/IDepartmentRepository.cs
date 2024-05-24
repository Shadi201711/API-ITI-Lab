using Day2.Models;
using Microsoft.EntityFrameworkCore;

namespace Day2.Repository
{
    public interface IDepartmentRepository
    {
        
        public IEnumerable<Department> GetAllDepartments();
       
        public Department GetDepartmentById(int id);
      
        public void AddDepartment(Department department);
     
        public void UpdateDepartment(Department department);
      
        public void DeleteDepartment(int id);
       
        public void Save();
       
    }
}
