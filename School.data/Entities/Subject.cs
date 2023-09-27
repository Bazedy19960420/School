using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace School.data.Entities
{
    public class Subject
    {
        public Subject()
        {
            StudentsSubjects = new HashSet<StudentSubject>();
            DepartmetsSubjects = new HashSet<DepartmentSubject>();
            InsSubjects = new HashSet<InsSubject>();
        }
        [Key]
        public int SubID { get; set; }
        [StringLength(500)]
        public string SubjectName { get; set; } = string.Empty;
        public int? Period { get; set; }
        [InverseProperty(nameof(StudentSubject.Subject))]
        public virtual ICollection<StudentSubject> StudentsSubjects { get; set; }
        [InverseProperty(nameof(DepartmentSubject.Subjects))]
        public virtual ICollection<DepartmentSubject> DepartmetsSubjects { get; set; }
        [InverseProperty(nameof(InsSubject.Subject))]
        public virtual ICollection<InsSubject> InsSubjects { get; set; }
    }
}
