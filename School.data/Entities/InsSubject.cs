using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace School.data.Entities
{
    public class InsSubject
    {
        [Key]
        public int InsId { get; set; }
        [Key]
        public int SubId { get; set; }
        [ForeignKey(nameof(InsId))]
        [InverseProperty("InsSubjects")]
        public virtual Instructor Instructor { get; set; } = default!;
        [ForeignKey(nameof(SubId))]
        [InverseProperty("InsSubjects")]
        public virtual Subject Subject { get; set; } = default!;
    }
}
