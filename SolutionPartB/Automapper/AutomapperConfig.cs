using System;
using AutoMapper;
namespace SolutionPartB.Automapper
{
    public class AutomapperConfig
    {
        public static MapperConfiguration RegisterConfig(){
            return new MapperConfiguration(cfg => {
                cfg.AddProfile<EntityToViewModel>();
                cfg.AddProfile<ViewModelToEntity>();
            });
        }
    }
}
