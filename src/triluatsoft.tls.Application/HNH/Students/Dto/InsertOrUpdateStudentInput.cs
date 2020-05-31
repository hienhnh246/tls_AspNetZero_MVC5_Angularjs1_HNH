using Abp.AutoMapper;
using System;
using System.ComponentModel.DataAnnotations;
using triluatsoft.tls.HNH.People;

namespace triluatsoft.tls.HNH.Students.Dto
{
    [AutoMapTo(typeof(Student))]
    public class InsertOrUpdateStudentInput
    {
        public int? Id { get; set; }

        [Required]
        [MaxLength(Student.MaxNameLength)]
        public string Name { get; set; }

        [Required]
        [MaxLength(Student.MaxSurnameLength)]
        public string Surname { get; set; }

        public DateTime? Birth { get; set; }

        [Required]
        public Gender Gender { get; set; }

        [StringLength(Student.MaxNumberLength)]
        public string PhoneNumber { get; set; }

        [StringLength(Student.MaxEmailAddressLength)]
        public string EmailAddress { get; set; }
    }
}
