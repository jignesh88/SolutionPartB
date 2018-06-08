using System;
namespace SolutionPartB.WebApi.Model
{
    public class GlossaryTermModel
    {
        public Guid GlossaryTermId { get; set; }
        public string Term { get; set; }
        public string Defination { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
