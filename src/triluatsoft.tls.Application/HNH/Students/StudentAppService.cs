using Abp.Application.Services.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;
using triluatsoft.tls.HNH.Students.Dto;

namespace triluatsoft.tls.HNH.Students
{
    public class StudentAppService : tlsAppServiceBase, IStudentAppService
    {
        private readonly IStudentManager _studentManager;

        public StudentAppService(IStudentManager studentManager)
        {
            _studentManager = studentManager;
        }

        public async Task<ListResultDto<StudentListDto>> GetStudents()
        {
            var students = await _studentManager.GetAllStudentListAsync();

            var result = new ListResultDto<StudentListDto>(ObjectMapper.Map<List<StudentListDto>>(students));

            return result;
        }

        public async Task<ListResultDto<StudentListDto>> GetStudentsPagination(PagedAndFilteredStudentInput input)
        {
            var totalCount = await _studentManager.CountTotalAllStudentAsync();
            var students = await _studentManager.GetStudentListWithFilterAndPaginationAsync(input.Filter, input.SkipCount, input.MaxResultCount);

            var result = new PagedResultDto<StudentListDto>(totalCount, ObjectMapper.Map<List<StudentListDto>>(students));

            return result;
        }

        public async Task<StudentDto> GetStudent(EntityDto input)
        {
            var student = await _studentManager.GetStudentAsync(input.Id);

            var result = ObjectMapper.Map<StudentDto>(student);

            return result;
        }

        public async Task CreateStudent(InsertOrUpdateStudentInput input)
        {
            var student = ObjectMapper.Map<Student>(input);

            await _studentManager.InsertStudentAsync(student);
        }

        public async Task UpdateStudent(InsertOrUpdateStudentInput input)
        {
            var student = ObjectMapper.Map<Student>(input);

            await _studentManager.UpdateStudentAsync(student);
        }

        public async Task DeleteStudent(EntityDto input)
        {
            await _studentManager.DeleteStudentAsync(input.Id);
        }

        public async Task<ListResultDto<StudentListDto>> GetStudentsInClassroom(int classroomIdInput)
        {
            var students = await _studentManager.GetStudentsInClassroom(classroomIdInput);

            var result = new ListResultDto<StudentListDto>(ObjectMapper.Map<List<StudentListDto>>(students));

            return result;
        }
    }
}
