using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace School.data.Entities
{
    public class Student
    {
        public Student()
        {
            StudentsSubjects = new HashSet<StudentSubject>();
        }
        [Key]
        public int StudID { get; set; }
        [StringLength(200)]
        public string Name { get; set; } = string.Empty;
        [StringLength(500)]
        public string Address { get; set; } = string.Empty;
        [StringLength(500)]
        public string Phone { get; set; } = string.Empty;
        public int? DID { get; set; }

        [ForeignKey("DID")]
        [InverseProperty("Students")]
        public virtual Department? Department { get; set; } = default!;
        [InverseProperty(nameof(StudentSubject.Student))]
        public virtual ICollection<StudentSubject> StudentsSubjects { get; set; } = default!;
    }
}
