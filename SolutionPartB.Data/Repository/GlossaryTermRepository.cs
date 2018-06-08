using System;
using SolutionPartB.Data.Entity;
namespace SolutionPartB.Data.Repository
{
    public class GlossaryTermRepository : Repository<GlossaryTerm>, IGloassaryTermRepository
    {
        public GlossaryTermRepository(GlossaryTermDBContext context)
            :base(context)
        {

        }
    }
}
