using Microsoft.EntityFrameworkCore;
using School.data.Entities;
using School.data.Helpers;
using School.infrastructure.Repositories.Abstract.StudentAbstract;
using School.service.Abstracts;

namespace School.service.Services
{
    public class StudentService : IStudentService
    {
        #region private members
        private readonly IStudentRepository _studentRepository;
        #endregion
        #region constructor
        public StudentService(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }


        #endregion

        #region public methods
        public async Task<List<Student>> GetStudentsListAsync()
        {
            return await _studentRepository.GetStudentsListAsync();
        }
        public async Task<Student> GetStudentByIdAsync(int id)
        {
            var student = _studentRepository.GetTableNoTracking().Include(d => d.Department).Where(d => d.StudID==id).FirstOrDefault();
            return student!;
        }
        public async Task<Student> GetByIdAsync(int id)
        {
            var student = _studentRepository.GetTableNoTracking().Where(d => d.StudID == id).FirstOrDefault();
            return student!;
        }
        public async Task<string> AddAsync(Student student)
        {

            await _studentRepository.AddAsync(student);
            return ("Success");

        }

        public async Task<bool> IsNameExist(string name)
        {
            var studentExist = _studentRepository.GetTableNoTracking().Where(d => d.Name == name).FirstOrDefault();
            if (studentExist == null)
            {
                return false;
            }
            return true;

        }

        public async Task<bool> IsNameExistExludeSelf(string name, int id)
        {
            var studentExist = _studentRepository.GetTableNoTracking().Where(d => d.Name == name & d.StudID != id).FirstOrDefault();
            if (studentExist == null)
            {
                return false;
            }
            return true;
        }
        public async Task<string> EditAsync(Student student)
        {
            await _studentRepository.UpdateAsync(student);
            return ("Success");
        }

        public async Task<string> DeleteAsync(Student student)
        {
            var transaction = _studentRepository.BeginTransaction();
            try
            {
                await _studentRepository.DeleteAsync(student);
                _studentRepository.Commit();
                return ("Success");
            }
            catch (Exception ex)
            {
                _studentRepository.RollBack();
                return ("Failed");
            }

        }

        public IQueryable<Student> GetStudentsQueryable()
        {
            return _studentRepository.GetTableAsTracking().Include(d => d.Department).AsQueryable();
        }

        public IQueryable<Student> FilterStudentPaginatedQueryable(StudentOrderingEnum orderingEnum, string search)
        {
            var queryable = _studentRepository.GetTableAsTracking().Include(d => d.Department).AsQueryable();
            if (!string.IsNullOrEmpty(search))
            {
                queryable = queryable.Where(s => s.Name.Contains(search) || s.Address.Contains(search));
            }
            switch (orderingEnum)
            {
                case StudentOrderingEnum.studID:
                    queryable = queryable.OrderBy(s => s.StudID);
                    break;
                case StudentOrderingEnum.Name:
                    queryable = queryable.OrderBy(s => s.Name);
                    break;
                case StudentOrderingEnum.Address:
                    queryable = queryable.OrderBy(s => s.Address);
                    break;
                case StudentOrderingEnum.DepartmentName:
                    queryable = queryable.OrderBy(s => s.Department.DName);
                    break;

            }

            return queryable;
        }

        #endregion

    }
}
