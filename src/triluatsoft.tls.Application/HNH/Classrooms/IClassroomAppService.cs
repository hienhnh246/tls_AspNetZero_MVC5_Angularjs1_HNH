using Abp.Application.Services;
using Abp.Application.Services.Dto;
using System.Threading.Tasks;
using triluatsoft.tls.HNH.Classrooms.Dto;

namespace triluatsoft.tls.HNH.Classrooms
{
    public interface IClassroomAppService : IApplicationService
    {
        Task<ListResultDto<ClassroomListDto>> GetAllClassroom();

        Task<PagedResultDto<ClassroomListDto>> GetClassroomsPagination(PagedAndFilteredClassroomInput input);

        Task<ClassroomDto> GetClassroom(EntityDto input);

        Task CreateClassroom(InsertOrUpdateClassroomInput input);

        Task UpdateClassroom(InsertOrUpdateClassroomInput input);

        Task CreateOrUpdateClassroom(InsertOrUpdateClassroomInput input);

        Task DeleteClassroom(EntityDto input);
    }
}
