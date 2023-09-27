using School.data.Entities;

namespace School.service.Abstracts
{
    public interface IDepartmentService
    {
        public Task<Department> GetDepartmentById(int id);
    }
}
