using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using triluatsoft.tls.HNH.Phones;

namespace triluatsoft.tls.HNH.People.Dto
{
    [AutoMapFrom(typeof(Phone))]
    public class PhoneInPersonListDto : CreationAuditedEntityDto<long>
    {
        public PhoneType Type { get; set; }

        public string Number { get; set; }
    }
}
