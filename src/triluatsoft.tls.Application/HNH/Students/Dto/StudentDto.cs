using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;
using triluatsoft.tls.HNH.People;

namespace triluatsoft.tls.HNH.Students.Dto
{
    [AutoMapFrom(typeof(Student))]
    public class StudentDto : FullAuditedEntityDto
    {
        public string Name { get; set; }

        public string Surname { get; set; }

        public DateTime? Birth { get; set; }

        public Gender Gender { get; set; }

        public string PhoneNumber { get; set; }

        public string EmailAddress { get; set; }
    }
}
