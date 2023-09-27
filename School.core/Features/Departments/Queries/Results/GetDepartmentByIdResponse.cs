namespace School.core.Features.Departments.Queries.Results
{
    public class GetDepartmentByIdResponse
    {
        public int DID { get; set; }
        public string DName { get; set; } = string.Empty;
        public string ManagerName { get; set; } = string.Empty;
        public List<StudentResponse> Students { get; set; } = new List<StudentResponse>();
        public List<InstructorResponse> Instructors { get; set; } = new List<InstructorResponse>();
        public List<SubjectResponse> Subjects { get; set; } = new List<SubjectResponse>();
    }
    public class StudentResponse
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
    }
    public class InstructorResponse
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
    }
    public class SubjectResponse
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
    }
}
