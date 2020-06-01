using Abp.AutoMapper;
using System.ComponentModel.DataAnnotations;
using triluatsoft.tls.HNH.Classrooms;
using triluatsoft.tls.HNH.Students;

namespace triluatsoft.tls.HNH.StudentsAndClassrooms.Dto
{
    [AutoMapTo(typeof(StudentAndClassroom))]
    public class InsertStudentAndClassroomInput
    {
        public virtual Classroom Classroom { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public virtual int ClassroomId { get; set; }

        public virtual Student Student { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public virtual int StudentId { get; set; }
    }
}
