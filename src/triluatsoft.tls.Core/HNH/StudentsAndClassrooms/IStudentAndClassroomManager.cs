using Abp.Domain.Services;
using System.Threading.Tasks;

namespace triluatsoft.tls.HNH.StudentsAndClassrooms
{
    public interface IStudentAndClassroomManager :IDomainService
    {
        Task InsertStudentAndClassroomAsync(StudentAndClassroom studentAndClassroom);

        Task DeleteStudentAndClassroomAsync(int id);
    }
}
