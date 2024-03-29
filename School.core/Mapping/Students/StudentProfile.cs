﻿using AutoMapper;

namespace School.core.Mapping.Students
{
    public partial class StudentProfile : Profile
    {
        public StudentProfile()
        {
            GetStudentListMapping();
            GetStudentByIdMapping();
            AddStudentMapping();
            EditStudentMapping();
        }

    }
}
