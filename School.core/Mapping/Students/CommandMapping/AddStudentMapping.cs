using AutoMapper;
using School.core.Features.Students.Commands.Models;
using School.data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.core.Mapping.Students
{
    public partial class StudentProfile
    {
        public void AddStudentMapping()
        {
            CreateMap<AddStudentCommand, Student>().ForMember(Student => Student.DID, opt => opt.MapFrom(src => src.DepartmentId));
        }
    }
}
