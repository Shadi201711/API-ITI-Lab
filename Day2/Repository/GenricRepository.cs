using Day2.Models;

namespace Day2.Repository
{
    public class GenricRepository<TEnity> where TEnity : class
    {
        ITIContext _context;
        public GenricRepository(ITIContext context)
        {
            _context = context;
        }
        public IEnumerable<TEnity> GetAll()
        {
            return _context.Set<TEnity>();
        }
        public TEnity GetById(int id)
        {
            return _context.Set<TEnity>().Find(id);
        }
        public void Add(TEnity entity)
        {
            _context.Set<TEnity>().Add(entity);

        }
        public void Update(TEnity entity)
        {
            _context.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

        }
        public void Delete(int id)
        {
            var entity = _context.Set<TEnity>().Find(id);
            _context.Set<TEnity>().Remove(entity);

        }
        public void Save()
        {
            _context.SaveChanges();
        }
    }
}