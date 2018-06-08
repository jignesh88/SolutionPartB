using System;
using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
namespace SolutionPartB.Automapper
{
    public static class  AutomapperSetup
    {
        public static void AddAutomapperSetup(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentException(nameof(services));

            services.AddAutoMapper();

            AutomapperConfig.RegisterConfig();
        }
    }
}
