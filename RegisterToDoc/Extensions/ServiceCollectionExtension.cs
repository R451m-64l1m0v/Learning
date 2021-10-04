using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using RegisterToDoc.Models;
using RegisterToDoc.Validators;

namespace RegisterToDoc.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddValidators(this IServiceCollection services)
        {
            services.AddFluentValidation();

            services.AddTransient<IValidator<DoctorDto>, DoctorDtoValidator>();

            services.AddTransient<IValidator<WorkGraphicDto>, WorkGraphicValidator>();

            return services;
        }
    }
}
