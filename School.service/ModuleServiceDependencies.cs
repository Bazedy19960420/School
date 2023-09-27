using Microsoft.Extensions.DependencyInjection;
using School.service.Abstracts;
using School.service.Services;

namespace School.service
{
    public static class ModuleServiceDependencies
    {
        public static IServiceCollection AddServiceDependencies(this IServiceCollection services)
        {
            services.AddTransient<IStudentService, StudentService>();
            services.AddTransient<IDepartmentService, DepartmentService>();
            return services;
        }

    }
}