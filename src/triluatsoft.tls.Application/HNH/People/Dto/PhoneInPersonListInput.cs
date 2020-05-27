using Abp.AutoMapper;
using triluatsoft.tls.HNH.Phones;

namespace triluatsoft.tls.HNH.People.Dto
{
    [AutoMapTo(typeof(Phone))]
    public class PhoneInPersonListInput
    {
        public int Id { get; set; }

        public PhoneType Type { get; set; }

        public string Number { get; set; }
    }
}
