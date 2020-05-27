using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System.Collections.ObjectModel;

namespace triluatsoft.tls.HNH.People.Dto
{
    [AutoMapFrom(typeof(Person))]
    public class PersonListDto : FullAuditedEntityDto
    {
        public string Name { get; set; }

        public string Surname { get; set; }

        public string EmailAddress { get; set; }

        public Collection<PhoneInPersonListDto> Phones { get; set; }
    }
}
