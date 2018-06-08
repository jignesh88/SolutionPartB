using System;
using SolutionPartB.Data.Entity;
using AutoMapper;
using SolutionPartB.Models;

namespace SolutionPartB.Automapper
{
    public class ViewModelToEntity : Profile
    {
        public ViewModelToEntity()
        {
            CreateMap<GlossaryTermViewModel, GlossaryTerm>();
                
        }
    }
}
