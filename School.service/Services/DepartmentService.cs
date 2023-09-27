using Microsoft.EntityFrameworkCore;
using School.data.Entities;
using School.infrastructure.Repositories.Abstract;
using School.service.Abstracts;

namespace School.service.Services
{

    public class DepartmentService : IDepartmentService
    {
        #region privateMembers
        private readonly IDepartmentRepository _departmentRepository;
        #endregion
        #region Constructor
        public DepartmentService(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }
        #endregion
        public async Task<Department> GetDepartmentById(int id)
        {
            var department = await _departmentRepository.GetTableNoTracking().Where(x => x.DID == id)
                .Include(x => x.InsManager)
                .Include(x => x.Instructors)
                .Include(x => x.Students)
                .Include(x => x.DepartmentSubjects)
                .ThenInclude(x => x.Subjects)
                .FirstOrDefaultAsync();
            return department;

        }
    }
}
