using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
namespace SolutionPartB.Data.Repository
{
    public abstract class Repository <T> : IReporistory<T> where T : class
    {
        private readonly GlossaryTermDBContext _context;

        private readonly DbSet<T> dbSet;

        private Repository()
        {
        }

        public Repository(GlossaryTermDBContext context){

            _context = context;
            dbSet = _context.Set<T>();
        }

        public void Add(T item)
        {
            dbSet.Add(item);
        }

        public void Delete(T item)
        {
            dbSet.Remove(item);
        }

        public IQueryable<T> GetAll()
        {
            return dbSet;
        }

        public T GetById(Guid id)
        {
            return dbSet.Find(id);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public void Update(T item)
        {
            dbSet.Update(item);
        }
    }
}
