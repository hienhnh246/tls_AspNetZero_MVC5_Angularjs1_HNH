using Abp.AutoMapper;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace triluatsoft.tls.HNH.People.Dto
{
    [AutoMapTo(typeof(Person))]
    public class EditPersonInput
    {
        [Required]
        [Range(1, int.MaxValue)]
        public int Id { get; set; }

        [Required]
        [MaxLength(Person.MaxNameLength)]
        public string Name { get; set; }

        [Required]
        [MaxLength(Person.MaxSurnameLength)]
        public string Surname { get; set; }

        [EmailAddress]
        [MaxLength(Person.MaxEmailAddressLength)]
        public string EmailAddress { get; set; }

        public Collection<PhoneInPersonListInput> Phones { get; set; }
    }
}
