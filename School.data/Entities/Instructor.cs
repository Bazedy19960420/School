using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace School.data.Entities
{
    public class Instructor
    {
        public Instructor()
        {
            Instructors = new HashSet<Instructor>();
            InsSubjects = new HashSet<InsSubject>();
        }
        [Key]
        public int InsId { get; set; }
        public string InsName { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string Position { get; set; } = string.Empty;
        public int? SuperVisorId { get; set; }

        public decimal Salary { get; set; }
        public int? DID { get; set; }
        [ForeignKey(nameof(DID))]
        [InverseProperty("Instructors")]
        public virtual Department? Department { get; set; } = default!;
        [InverseProperty("InsManager")]
        public virtual Department? DepartmentManager { get; set; } = default!;
        [ForeignKey(nameof(SuperVisorId))]
        [InverseProperty(nameof(Instructor.Instructors))]
        public virtual Instructor? SuperVisor { get; set; } = default!;
        [InverseProperty(nameof(Instructor.SuperVisor))]
        public virtual ICollection<Instructor> Instructors { get; set; } = default!;
        [InverseProperty(nameof(InsSubject.Instructor))]
        public virtual ICollection<InsSubject> InsSubjects { get; set; } = default!;
    }
}
