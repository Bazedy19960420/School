using Microsoft.EntityFrameworkCore;
using School.data.Entities;
using School.infrastructure.Data;
using School.infrastructure.InfrastructureBases;
using School.infrastructure.Repositories.Abstract.StudentAbstract;

namespace School.infrastructure.Repositories
{
    public class StudentRepository : GenericRepository<Student>,IStudentRepository
    {
        #region Private Members
        private readonly DbSet<Student> _studentContext;
        #endregion

        #region Constructor
        public StudentRepository(AppDbContext context):base(context)
        {
            _studentContext = context.Set<Student>();
        }
        #endregion

        #region Public Methods
        public async Task<List<Student>> GetStudentsListAsync()
        {
            return await _studentContext.Include(d => d.Department).ToListAsync();
        }
       
        #endregion
    }
}
