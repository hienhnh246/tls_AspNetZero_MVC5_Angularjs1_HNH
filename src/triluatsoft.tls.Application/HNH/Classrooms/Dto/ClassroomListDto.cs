using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System.Collections.ObjectModel;
using triluatsoft.tls.HNH.StudentsAndClassrooms.Dto;

namespace triluatsoft.tls.HNH.Classrooms.Dto
{
    [AutoMapFrom(typeof(Classroom))]
    public class ClassroomListDto : FullAuditedEntityDto
    {
        public string Name { get; set; }

        public int MaxStudentAmount { get; set; }

        public ClassroomType ClassroomType { get; set; }

        public string Description { get; set; }

        public virtual Collection<StudentAndClassroomListDto> StudentsAndClassrooms { get; set; }
    }
}
