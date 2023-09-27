using School.core.Features.Students.Commands.Models;
using School.data.Entities;

namespace School.core.Mapping.Students
{
    public partial class StudentProfile
    {
        public void EditStudentMapping()
        {
            CreateMap<EditStudentCommand, Student>().ForMember(Student => Student.DID, opt => opt.MapFrom(src => src.DepartmentId))
                .ForMember(Student => Student.StudID, opt => opt.MapFrom(src => src.Id));

        }
    }
}