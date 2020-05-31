using Abp.Domain.Entities.Auditing;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using triluatsoft.tls.HNH.People;

namespace triluatsoft.tls.HNH.Students
{
    [Table("HNHStudents")]
    public class Student : FullAuditedEntity, IPerson
    {
        public const int MaxNameLength = 32;
        public const int MaxSurnameLength = 32;
        public const int MaxNumberLength = 16;
        public const int MaxEmailAddressLength = 255;

        [Required]
        [MaxLength(MaxNameLength)]
        public virtual string Name { get; set; }

        [Required]
        [MaxLength(MaxSurnameLength)]
        public virtual string Surname { get; set; }

        public virtual DateTime? Birth { get; set; }

        [Required]
        public virtual Gender Gender { get; set; }

        [StringLength(MaxNumberLength)]
        public virtual string PhoneNumber { get; set; }

        [StringLength(MaxEmailAddressLength)]
        public virtual string EmailAddress { get; set; }
    }
}
