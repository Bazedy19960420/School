using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace School.data.Entities
{
    public partial class Department
    {
        public Department()
        {
            Students = new HashSet<Student>();
            DepartmentSubjects = new HashSet<DepartmentSubject>();
        }
        [Key]
        public int DID { get; set; }
        [StringLength(500)]
        public string DName { get; set; } = string.Empty;
        public virtual ICollection<Student> Students { get; set; }
        [InverseProperty(nameof(DepartmentSubject.Department))]
        public virtual ICollection<DepartmentSubject> DepartmentSubjects { get; set; }
        [InverseProperty(nameof(Instructor.Department))]
        public virtual ICollection<Instructor> Instructors { get; set; } = default!;
        public int? InsManagerId { get; set; }
        [ForeignKey(nameof(InsManagerId))]
        [InverseProperty(nameof(Instructor.DepartmentManager))]
        public virtual Instructor? InsManager { get; set; } = default!;
    }
}
