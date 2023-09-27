using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace School.data.Entities
{
    public class StudentSubject
    {
        [Key]

        public int StudID { get; set; }
        [Key]
        public int SubID { get; set; }

        [ForeignKey("StudID")]
        [InverseProperty("StudentsSubjects")]
        public virtual Student Student { get; set; } = default!;

        [ForeignKey("SubID")]
        public virtual Subject Subject { get; set; } = default!;
        public decimal? Grade { get; set; }

    }
}
