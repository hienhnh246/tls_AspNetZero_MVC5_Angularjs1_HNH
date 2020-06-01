using Abp.Application.Services;
using Abp.Application.Services.Dto;
using System.Threading.Tasks;
using triluatsoft.tls.HNH.StudentsAndClassrooms.Dto;

namespace triluatsoft.tls.HNH.StudentsAndClassrooms
{
    public interface IStudentAndClassroomAppService : IApplicationService
    {
        Task CreateStudentAndClassroom(InsertStudentAndClassroomInput input);

        Task DeleteStudentAndClassroom(EntityDto input);
    }
}
