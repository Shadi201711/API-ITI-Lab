using Day2.Models;
using Day2.Repository;

namespace Day2.UnitOfWork
{
    public class Unit
    {
            ITIContext _context;
        public GenricRepository<Department> DepartmentRepo;
        public GenricRepository<Student> StudentRepo;
        public Unit(ITIContext context)
        {
            _context = context;
        }
        public GenricRepository<Department> DepartmentRepository
        {
            get
            {
                if (this.DepartmentRepo == null)
                {
                    this.DepartmentRepo = new GenricRepository<Department>(_context);
                }
                return DepartmentRepo;
            }
        }
        public GenricRepository<Student> StudentRepository
        {
            get
            {
                if (this.StudentRepo == null)
                {
                    this.StudentRepo = new GenricRepository<Student>(_context);
                }
                return StudentRepo;
            }
        }
        public void Save()
        {
            _context.SaveChanges();
        }
   
        
    }
}
