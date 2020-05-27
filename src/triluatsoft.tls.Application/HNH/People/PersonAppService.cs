using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Collections.Extensions;
using Abp.Domain.Repositories;
using Abp.Extensions;
using Abp.Linq.Extensions;
using Castle.MicroKernel.ModelBuilder.Inspectors;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using triluatsoft.tls.Authorization;
using triluatsoft.tls.HNH.People.Dto;
using triluatsoft.tls.HNH.Phones;

namespace triluatsoft.tls.HNH.People
{
    [AbpAuthorize(AppPermissions.Pages_Tenant_PhoneBook)]
    public class PersonAppService : tlsAppServiceBase, IPersonAppService
    {
        private readonly IRepository<Person> _personRepository;
        private readonly IRepository<Phone, long> _phoneRepository;

        public PersonAppService(IRepository<Person> personRepository, IRepository<Phone, long> phoneRepository)
        {
            _personRepository = personRepository;
            _phoneRepository = phoneRepository;
        }

        public async Task<ListResultDto<PersonListDto>> GetPeople(GetPeopleInput input)
        {
            var persons = await _personRepository
            .GetAll()
            .Include(p => p.Phones)
            .WhereIf(
                !input.Filter.IsNullOrEmpty(),
                p => p.Name.Contains(input.Filter) ||
                        p.Surname.Contains(input.Filter) ||
                        p.EmailAddress.Contains(input.Filter)
            )
            .OrderBy(p => p.Name)
            .ThenBy(p => p.Surname)
            .ToListAsync();

            return new ListResultDto<PersonListDto>(ObjectMapper.Map<List<PersonListDto>>(persons));
        }

        public async Task<GetPersonForEditOutput> GetPersonForEdit(GetPersonForEditInput input)
        {
            var person = await _personRepository.GetAsync(input.Id);
            return ObjectMapper.Map<GetPersonForEditOutput>(person);
        }

        [AbpAuthorize(AppPermissions.Pages_Tenant_PhoneBook_CreatePerson)]
        public async Task CreatePerson(CreatePersonInput input)
        {
            var person = ObjectMapper.Map<Person>(input);

            await _personRepository.InsertAsync(person);
        }

        [AbpAuthorize(AppPermissions.Pages_Tenant_PhoneBook_EditPerson)]
        public async Task EditPerson(EditPersonInput input)
        {
            var person = await _personRepository.GetAsync(input.Id);
            person.Name = input.Name;
            person.Surname = input.Surname;
            person.EmailAddress = input.EmailAddress;

            _personRepository.Update(person);

            for (int i = 0; i < input.Phones.Count(); i++)
            {
                var phone = await _phoneRepository.GetAsync(input.Phones[i].Id);
                phone.Number = input.Phones[i].Number;
                phone.Type = input.Phones[i].Type;

                _phoneRepository.Update(phone);
            }

            await CurrentUnitOfWork.SaveChangesAsync();
        }

        [AbpAuthorize(AppPermissions.Pages_Tenant_PhoneBook_DeletePerson)]
        public async Task DeletePerson(EntityDto input)
        {
            await _personRepository.DeleteAsync(input.Id);
        }

        public async Task<GetPhoneForEditOutput> GetPhoneForEdit(GetPhoneForEditInput input)
        {
            var phone = await _phoneRepository.GetAsync(input.Id);
            return ObjectMapper.Map<GetPhoneForEditOutput>(phone);
        }

        public async Task<PhoneInPersonListDto> AddPhone(AddPhoneInput input)
        {
            var person = _personRepository.Get(input.PersonId);

            var phone = ObjectMapper.Map<Phone>(input);
            person.Phones.Add(phone);

            await CurrentUnitOfWork.SaveChangesAsync();

            return ObjectMapper.Map<PhoneInPersonListDto>(phone);
        }              

        public async Task EditPhone(EditPhoneInput input)
        {
            var phone = ObjectMapper.Map<Phone>(input);

            await _phoneRepository.UpdateAsync(phone);
        }

        public async Task DeletePhone(EntityDto<long> input)
        {
            await _phoneRepository.DeleteAsync(input.Id);
        }
    }
}
