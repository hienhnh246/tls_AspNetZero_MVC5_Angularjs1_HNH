using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System.ComponentModel.DataAnnotations;
using triluatsoft.tls.HNH.Phones;

namespace triluatsoft.tls.HNH.People.Dto
{
    [AutoMapFrom(typeof(Phone))]
    public class GetPhoneForEditOutput : CreationAuditedEntityDto<long>
    {
        public int PersonId { get; set; }

        public PhoneType Type { get; set; }

        public string Number { get; set; }
    }
}
