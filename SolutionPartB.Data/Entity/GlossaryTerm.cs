using System;
namespace SolutionPartB.Data.Entity
{
    public class GlossaryTerm : Entity
    {
        public Guid GlossaryTermId { get; set; }
        public string Term { get; set; }
        public string Defination { get; set; }

    }
}
