using System;
namespace SolutionPartB.Data.Entitry
{
    public abstract class Entity
    {
        public Guid Id { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
