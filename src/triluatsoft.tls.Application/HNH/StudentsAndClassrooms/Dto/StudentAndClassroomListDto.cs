using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using triluatsoft.tls.HNH.Classrooms;
using triluatsoft.tls.HNH.Students;

namespace triluatsoft.tls.HNH.StudentsAndClassrooms.Dto
{
    [AutoMapFrom(typeof(StudentAndClassroom))]
    public class StudentAndClassroomListDto : FullAuditedEntityDto
    { 
        public int ClassroomId { get; set; }

        public int StudentId { get; set; }
    }
}
