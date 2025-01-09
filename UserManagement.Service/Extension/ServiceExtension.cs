

using FluentValidation.AspNetCore;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using UserManagement.Repository.UnitOfWorks.Abstract;
using UserManagement.Repository.UnitOfWorks.Concrete;
using UserManagement.Service.FluentValidation.Account;
using UserManagement.Service.FluentValidation.Identity.AppRoles;
using UserManagement.Service.FluentValidation.Identity.AppUsers;
using System.Reflection;
using AutoMapper;

namespace UserManagement.Service.Extension
{
    public static  class ServiceExtension
    {
        public static IServiceCollection AddService(this IServiceCollection service)
        {
            //add all repository
            service.AddTransient<IUnitOfWork, UnitOfWork>();

            //inject all services dynamic
            var types = Assembly.GetExecutingAssembly().GetTypes().Where(x => x.IsClass && !x.IsAbstract && x.Name.EndsWith("Service"));
            foreach (var item in types)
            {
                var IService = item.GetInterfaces().FirstOrDefault(x => x.Name == $"I{item.Name}");
                if (IService != null)
                    service.AddScoped(IService, item);
            }

            //inject automapper
            service.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            //inject fluentvalidation
            service.AddFluentValidationAutoValidation(x => x.DisableDataAnnotationsValidation = true);
            service.AddValidatorsFromAssemblyContaining<CreateRoleValidation>();
            service.AddValidatorsFromAssemblyContaining<UpdateRoleValidation>();

            service.AddValidatorsFromAssemblyContaining<CreateUserValidation>();
            service.AddValidatorsFromAssemblyContaining<UpdateUserValidation>();

            service.AddValidatorsFromAssemblyContaining<LoginValidation>();
            service.AddValidatorsFromAssemblyContaining<RegisterValidation>();




            return service;
        }
    }
}
