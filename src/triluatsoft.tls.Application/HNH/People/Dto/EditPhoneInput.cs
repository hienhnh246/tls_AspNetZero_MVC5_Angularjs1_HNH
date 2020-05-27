using Abp.AutoMapper;
using System.ComponentModel.DataAnnotations;
using triluatsoft.tls.HNH.Phones;

namespace triluatsoft.tls.HNH.People.Dto
{
    [AutoMapTo(typeof(Phone))]
    public class EditPhoneInput
    {
        [Required]
        [Range(1, int.MaxValue)]
        public int Id { get; set; }

        [Range(1, int.MaxValue)]
        public int PersonId { get; set; }

        [Required]
        public PhoneType Type { get; set; }

        [Required]
        [MaxLength(Phone.MaxNumberLength)]
        public string Number { get; set; }
    }
}
