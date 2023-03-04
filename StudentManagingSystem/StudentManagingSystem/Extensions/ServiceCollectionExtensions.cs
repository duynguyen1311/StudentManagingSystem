﻿using StudentManagingSystem.Repository.IRepository;
using StudentManagingSystem.Repository;

namespace ResumeSvc.Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration config)
        {
            // Đăng kí automapper
            //services.AddAutoMapper(typeof(AutoMapperProfile));

            // Đăng kí mediatR
            //services.AddMediatR(Assembly.GetExecutingAssembly());
            //services.AddMediatR(typeof(ViewUserProfileQuery).Assembly);

            // Đăng kí repository
            services.AddScoped(typeof(IDepartmentRepository), typeof(DepartmentRepository));
            services.AddScoped(typeof(IStudentRepository), typeof(StudentRepository));

            //Đăng kí service
            return services;
        }
    }
}
