using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;
using System.Collections.ObjectModel;
using triluatsoft.tls.HNH.People;
using triluatsoft.tls.HNH.StudentsAndClassrooms.Dto;

namespace triluatsoft.tls.HNH.Students.Dto
{
    [AutoMapFrom(typeof(Student))]
    public class StudentListDto : FullAuditedEntityDto
    {
        public string Name { get; set; }

        public string Surname { get; set; }

        public DateTime? Birth { get; set; }

        public Gender Gender { get; set; }

        public string PhoneNumber { get; set; }

        public string EmailAddress { get; set; }

        public Collection<StudentAndClassroomListDto> StudentsAndClassrooms { get; set; }
    }
}
