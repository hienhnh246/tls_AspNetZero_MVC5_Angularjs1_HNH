using Abp.Application.Services;
using Abp.Application.Services.Dto;
using System.Threading.Tasks;
using triluatsoft.tls.HNH.People.Dto;

namespace triluatsoft.tls.HNH.People
{
    public interface IPersonAppService : IApplicationService
    {
        Task<ListResultDto<PersonListDto>> GetPeople(GetPeopleInput input);

        Task<GetPersonForEditOutput> GetPersonForEdit(GetPersonForEditInput input);

        Task CreatePerson(CreatePersonInput input);

        Task EditPerson(EditPersonInput input);

        Task DeletePerson(EntityDto input);

        Task<GetPhoneForEditOutput> GetPhoneForEdit(GetPhoneForEditInput input);

        Task<PhoneInPersonListDto> AddPhone(AddPhoneInput input);

        Task EditPhone(EditPhoneInput input);

        Task DeletePhone(EntityDto<long> input);
    }
}
