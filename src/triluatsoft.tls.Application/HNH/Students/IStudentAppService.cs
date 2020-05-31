using Abp.Application.Services;
using Abp.Application.Services.Dto;
using System.Threading.Tasks;
using triluatsoft.tls.HNH.Students.Dto;

namespace triluatsoft.tls.HNH.Students
{
    public interface IStudentAppService : IApplicationService
    {
        Task<ListResultDto<StudentListDto>> GetStudents();

        Task<StudentDto> GetStudent(EntityDto input);

        Task CreateStudent(InsertOrUpdateStudentInput input);

        Task UpdateStudent(InsertOrUpdateStudentInput input);

        Task DeleteStudent(EntityDto input);
    }
}
