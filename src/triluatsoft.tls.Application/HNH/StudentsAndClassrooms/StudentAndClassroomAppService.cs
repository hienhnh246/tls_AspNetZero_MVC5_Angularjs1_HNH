using Abp.Application.Services.Dto;
using System.Threading.Tasks;
using triluatsoft.tls.HNH.StudentsAndClassrooms.Dto;

namespace triluatsoft.tls.HNH.StudentsAndClassrooms
{
    public class StudentAndClassroomAppService : tlsAppServiceBase, IStudentAndClassroomAppService
    {
        private readonly IStudentAndClassroomManager _studentAndClassroomManager;

        public StudentAndClassroomAppService(IStudentAndClassroomManager studentAndClassroomManager)
        {
            _studentAndClassroomManager = studentAndClassroomManager;
        }

        public async Task CreateStudentAndClassroom(InsertStudentAndClassroomInput input)
        {
            var studentAndClassroom = ObjectMapper.Map<StudentAndClassroom>(input);

            await _studentAndClassroomManager.InsertStudentAndClassroomAsync(studentAndClassroom);
        }

        public async Task DeleteStudentAndClassroom(EntityDto input)
        {
            await _studentAndClassroomManager.DeleteStudentAndClassroomAsync(input.Id);
        }
    }
}
