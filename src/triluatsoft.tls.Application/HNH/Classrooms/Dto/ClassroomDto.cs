using Abp.Application.Services.Dto;
using Abp.AutoMapper;

namespace triluatsoft.tls.HNH.Classrooms.Dto
{
    [AutoMapFrom(typeof(Classroom))]
    public class ClassroomDto : FullAuditedEntityDto
    {
        public string Name { get; set; }

        public int MaxStudentAmount { get; set; }

        public ClassroomType ClassroomType { get; set; }

        public string Description { get; set; }
    }
}
