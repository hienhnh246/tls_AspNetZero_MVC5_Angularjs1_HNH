using Abp.Application.Services.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;
using triluatsoft.tls.HNH.Classrooms.Dto;

namespace triluatsoft.tls.HNH.Classrooms
{
    public class ClassroomAppService : tlsAppServiceBase, IClassroomAppService
    {
        private readonly IClassroomManager _classroomManager;

        public ClassroomAppService(IClassroomManager classroomManager)
        {
            _classroomManager = classroomManager;
        }

        public async Task<ListResultDto<ClassroomListDto>> GetAllClassroom()
        {
            var classrooms = await _classroomManager.GetAllClassroomListAsync();

            var result = new ListResultDto<ClassroomListDto>(ObjectMapper.Map<List<ClassroomListDto>>(classrooms));

            return result;
        }

        public async Task<PagedResultDto<ClassroomListDto>> GetClassroomsPagination(PagedAndFilteredClassroomInput input)
        {
            var totalCount = await _classroomManager.CountTotalAllClassroomAsync();
            var classrooms = await _classroomManager.GetClassroomListWithFilterAndPaginationAsync(input.Filter, input.SkipCount, input.MaxResultCount);

            var result = new PagedResultDto<ClassroomListDto>(totalCount, ObjectMapper.Map<List<ClassroomListDto>>(classrooms));

            return result;
        }

        public async Task<ClassroomDto> GetClassroom(EntityDto input)
        {
            var classroom = await _classroomManager.GetClassroomAsync(input.Id);

            var result = ObjectMapper.Map<ClassroomDto>(classroom);

            return result;
        }

        public async Task CreateClassroom(InsertOrUpdateClassroomInput input)
        {
            var classroom = ObjectMapper.Map<Classroom>(input);

            await _classroomManager.InsertClassroomAsync(classroom);
        }

        public async Task UpdateClassroom(InsertOrUpdateClassroomInput input)
        {
            var classroom = ObjectMapper.Map<Classroom>(input);

            await _classroomManager.UpdateClassroomAsync(classroom);
        }

        public async Task CreateOrUpdateClassroom(InsertOrUpdateClassroomInput input)
        {
            if (null == input.Id)
            {
                await CreateClassroom(input);
            }
            else
            {
                await UpdateClassroom(input);
            }
        }

        public async Task DeleteClassroom(EntityDto input)
        {
            await _classroomManager.DeleteClassroomAsync(input.Id);
        }
    }
}
