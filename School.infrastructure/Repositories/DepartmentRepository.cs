using Microsoft.EntityFrameworkCore;
using School.data.Entities;
using School.infrastructure.Data;
using School.infrastructure.InfrastructureBases;
using School.infrastructure.Repositories.Abstract;

namespace School.infrastructure.Repositories
{
    public class DepartmentRepository : GenericRepository<Department>, IDepartmentRepository
    {
        #region Private Members
        private readonly DbSet<Department> _dbSet;
        #endregion
        #region Constructors
        public DepartmentRepository(AppDbContext context) : base(context)
        {
            _dbSet = context.Set<Department>();
        }
        #endregion
    }
}
