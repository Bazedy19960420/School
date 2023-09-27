namespace School.core.Features.Students.Quries.Results
{
    public class GetStudentPaginatedListResponse
    {
        public int StudID { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string DepartmentName { get; set; } = string.Empty;
        public GetStudentPaginatedListResponse(int studID, string name, string address, string phone, string departmentName)
        {
            StudID = studID;
            Name = name;
            Address = address;
            Phone = phone;
            DepartmentName = departmentName;
        }
    }
}
