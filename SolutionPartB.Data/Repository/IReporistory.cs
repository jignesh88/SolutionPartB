using System;
using System.Collections.Generic;
using System.Linq;
namespace SolutionPartB.Data.Repository
{
    public interface IReporistory<T> where T: class
    {
        T GetById(Guid id);
        IQueryable<T> GetAll();
        void Add(T item);
        void Update(T item);
        void Delete(T item);
        void SaveChanges();
    }
}
