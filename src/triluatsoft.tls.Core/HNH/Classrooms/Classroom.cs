using Abp.Domain.Entities.Auditing;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using triluatsoft.tls.HNH.StudentsAndClassrooms;

namespace triluatsoft.tls.HNH.Classrooms
{
    [Table("HNHClassrooms")]
    public class Classroom : FullAuditedEntity
    {
        public const int MaxNameLength = 64;
        public const int MaxDescriptionLength = 2048;

        [Required]
        [StringLength(MaxNameLength)]
        public virtual string Name { get; set; }

        [Range(1, 50)]
        public virtual int MaxStudentAmount { get; set; }

        public virtual ClassroomType ClassroomType { get; set; }

        [StringLength(MaxDescriptionLength)]
        public virtual string Description { get; set; }

        public virtual ICollection<StudentAndClassroom> StudentsAndClassrooms { get; set; }
    }
}
