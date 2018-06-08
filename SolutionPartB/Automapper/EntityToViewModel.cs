using System;
using AutoMapper;
using SolutionPartB.Data.Entity;
using SolutionPartB.Models;
namespace SolutionPartB.Automapper
{
    public class EntityToViewModel : Profile
    {
        public EntityToViewModel()
        {
            CreateMap<GlossaryTerm, GlossaryTermViewModel>();
                
        }
    }
}
