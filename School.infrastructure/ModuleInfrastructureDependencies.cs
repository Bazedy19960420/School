using Microsoft.Extensions.DependencyInjection;
using School.infrastructure.InfrastructureBases;
using School.infrastructure.Repositories;
using School.infrastructure.Repositories.Abstract;
using School.infrastructure.Repositories.Abstract.StudentAbstract;

namespace School.infrastructure
{
    public static class ModuleInfrastructureDependencies
    {
        public static IServiceCollection AddInfrastructureDependencies(this IServiceCollection services)
        {
            services.AddTransient<IStudentRepository, StudentRepository>();
            services.AddTransient<IDepartmentRepository, DepartmentRepository>();
            services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            return services;
        }

    }
}