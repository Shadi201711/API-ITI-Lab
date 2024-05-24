using Day2.Models;

namespace Day2.Repository
{
    public class DepartmentRepository : IDepartmentRepository
    {
        ITIContext _context;
        public DepartmentRepository(ITIContext context)
        {
            _context = context;
        }
        public IEnumerable<Department> GetAllDepartments()
        {
            return _context.Departments.ToList();
        }
        public Department GetDepartmentById(int id)
        {
            return _context.Departments.Find(id);
        }
        public void AddDepartment(Department department)
        {
            _context.Departments.Add(department);
         //   _context.SaveChanges();
        }
        public void UpdateDepartment(Department department)
        {
            _context.Departments.Update(department);
         //   _context.SaveChanges();
        }
        public void DeleteDepartment(int id)
        {
            var department = _context.Departments.Find(id);
            _context.Departments.Remove(department);
          //  _context.SaveChanges();
        }
        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
