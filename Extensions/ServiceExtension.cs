﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentTeacher.Core.Mappings;
using StudentTeacher.Repository.Data;
using StudentTeacher.Service.Filters.ActionFilters;
using StudentTeacher.Service.Interfaces;
using StudentTeacher.Service.Services;

namespace StudentTeacher.Extensions
{
    public static class ServiceExtension
    {
        public static void ConfigureLoggerService(this IServiceCollection services) =>
        services.AddScoped<ILoggerManager, LoggerManager>();

        public static void ConfigureSqlContext(this IServiceCollection services, IConfiguration configuration) =>
            services.AddDbContext<RepositoryContext>(
                opts => opts.UseSqlServer(configuration.GetConnectionString("sqlConnection"),
                    b => b.MigrationsAssembly("StudentTeacher.Repo")));

        public static void ConfigureRepositoryManager(this IServiceCollection services)
            => services.AddScoped<IRepositoryManager, RepositoryManager>();

        public static void ConfigureMapping(this IServiceCollection services)
        {
            services.Configure<ApiBehaviorOptions>(options => { options.SuppressModelStateInvalidFilter = true; });
            var mapperConfig = new MapperConfiguration(map =>
            {
                map.AddProfile<TeacherMappingProfile>();
                map.AddProfile<StudentMappingProfile>();
            });
            services.AddSingleton(mapperConfig.CreateMapper());
        }

        //Add Here
        public static void ConfigureControllers(this IServiceCollection services)
        {
            services.AddControllers(config =>
            {
                config.CacheProfiles.Add("120SecondsDuration", new CacheProfile
                {
                    Duration = 30
                });
            });
        }

        //Add Here
        public static void ConfigureResponseCaching(this IServiceCollection services) => services.AddResponseCaching();


        public static void RegisterDependencies(this IServiceCollection services)
        {
            services.AddScoped<ValidationFilterAttribute>();
            services.AddScoped<ValidateTeacherExists>();
            services.AddScoped<ValidateStudentExistsForTeacher>();
        }
    }
}
