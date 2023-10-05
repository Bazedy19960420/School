namespace School.data.AppMetaData
{
    public static class Router
    {
        public const string SingleRoute = "/{id}";
        public const string root = "api/";
        public const string version = "v1/";
        public const string rule = root + version;
        public static class Students
        {
            public const string Controller = "students";
            public const string GetStudentList = rule + Controller + "/List";
            public const string GetStudentById = rule + Controller + SingleRoute;
            public const string Create = rule + Controller + "/create";
            public const string Edit = rule + Controller + "/Edit";
            public const string Delete = rule + Controller + "/Delete" + SingleRoute;
            public const string Paginated = rule + Controller + "/Paginated";

        }
        public static class Departments
        {
            const string Controller = "departments";
            public const string GetDepartmentList = rule + Controller + "/List";
            public const string GetDepartmentById = rule + Controller + SingleRoute;
        }
        public static class Auth
        {
            const string Controller = "auth";
            public const string Login = rule + Controller + "/login";
            public const string Register = rule + Controller + "/register";
            public const string Logout = rule + Controller + "/logout";
            public const string UserList = rule + Controller + "/userlist";
            public const string UserById = rule + Controller + "/userbyid" + SingleRoute;
            public const string UpdateUser = rule + Controller + "/updateuser";
            public const string DeleteUser = rule + Controller + "/deleteuser" + SingleRoute;
            public const string ChangePassword = rule + Controller + "/changepassword";
        }
    }
}
