//using Day2.Models;

//namespace Day2.Repository
//{
//    public class StudentRepository 
//    {
//        ITIContext _context;
//        public StudentRepository(ITIContext context)
//        {
//            _context = context;
//        }
//        public IEnumerable<Student> GetAllStudents()
//        {

//            return _context.Students.ToList();

//        }
//        public Student GetStudentById(int id)
//        {
//            return _context.Students.Find(id);
//        }
//        public void AddStudent(Student student)
//        {
//            _context.Students.Add(student); 
//           // _context.SaveChanges();
//        }
//        public void UpdateStudent(Student student)
//        {
//            _context.Entry(student).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
//            //_context.SaveChanges();
//        }
//        public void DeleteStudent(int id)
//        {
//            var student = _context.Students.Find(id);
//            _context.Students.Remove(student);
//           // _context.SaveChanges();
//        }
//        public void Save()
//        {
//            _context.SaveChanges();
//        }

//    }
//}
