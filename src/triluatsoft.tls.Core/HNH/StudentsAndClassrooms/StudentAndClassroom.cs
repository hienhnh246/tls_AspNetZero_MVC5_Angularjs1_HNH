using Abp.Domain.Entities.Auditing;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using triluatsoft.tls.HNH.Classrooms;
using triluatsoft.tls.HNH.Students;

namespace triluatsoft.tls.HNH.StudentsAndClassrooms
{
    [Table("HNHStudentsAndClassrooms")]
    public class StudentAndClassroom : FullAuditedEntity
    {
        [ForeignKey("ClassroomId")]
        public virtual Classroom Classroom { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public virtual int ClassroomId { get; set; }

        [ForeignKey("StudentId")]
        public virtual Student Student { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public virtual int StudentId { get; set; }          
    }
}
