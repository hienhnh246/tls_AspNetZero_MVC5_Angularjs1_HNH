using Abp.Application.Services;
using Abp.Application.Services.Dto;
using System.Threading.Tasks;
using triluatsoft.tls.HNH.Students.Dto;

namespace triluatsoft.tls.HNH.Students
{
    public interface IStudentAppService : IApplicationService
    {
        Task<ListResultDto<StudentListDto>> GetStudents();

        Task<ListResultDto<StudentListDto>> GetStudentsPagination(PagedAndFilteredStudentInput input);

        Task<StudentDto> GetStudent(EntityDto input);

        Task CreateStudent(InsertOrUpdateStudentInput input);

        Task UpdateStudent(InsertOrUpdateStudentInput input);

        Task DeleteStudent(EntityDto input);

        Task<ListResultDto<StudentListDto>> GetStudentsInClassroom(int classroomIdInput);
    }
}
