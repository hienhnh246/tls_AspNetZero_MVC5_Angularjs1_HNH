using Abp.AutoMapper;
using System.ComponentModel.DataAnnotations;

namespace triluatsoft.tls.HNH.Classrooms.Dto
{
    [AutoMapTo(typeof(Classroom))]
    public class InsertOrUpdateClassroomInput
    {
        public int? Id { get; set; }

        [Required]
        [StringLength(Classroom.MaxNameLength)]
        public string Name { get; set; }

        [Range(1, 50)]
        public int MaxStudentAmount { get; set; }

        public ClassroomType ClassroomType { get; set; }

        [StringLength(Classroom.MaxDescriptionLength)]
        public string Description { get; set; }
    }
}
