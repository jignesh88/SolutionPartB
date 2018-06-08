using System;
using SolutionPartB.Data.Entity;
using System.Linq;
namespace SolutionPartB.Data.Repository
{
    public interface IGloassaryTermRepository
    {
        GlossaryTerm GetById(Guid Id);
        IQueryable<GlossaryTerm> GetAll();
        void Update(GlossaryTerm term);
        void Delete(GlossaryTerm term);
        void Add(GlossaryTerm term);
        void SaveChanges();
    }
}
