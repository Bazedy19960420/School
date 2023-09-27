using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using School.data.Entities;
using School.infrastructure.InfrastructureBases;

namespace School.infrastructure.Repositories.Abstract.StudentAbstract
{
    public interface IStudentRepository : IGenericRepository<Student>
    {
        public Task<List<Student>> GetStudentsListAsync();
    }
}
