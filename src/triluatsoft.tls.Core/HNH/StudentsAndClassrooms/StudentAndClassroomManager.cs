using Abp.Domain.Repositories;
using System.Threading.Tasks;

namespace triluatsoft.tls.HNH.StudentsAndClassrooms
{
    public class StudentAndClassroomManager : tlsDomainServiceBase, IStudentAndClassroomManager
    {
        private readonly IRepository<StudentAndClassroom> _studentAndClassroomRepository;

        public StudentAndClassroomManager(IRepository<StudentAndClassroom> studentAndClassroomRepository)
        {
            _studentAndClassroomRepository = studentAndClassroomRepository;
        }

        public async Task InsertStudentAndClassroomAsync(StudentAndClassroom studentAndClassroom)
        {
            await _studentAndClassroomRepository.InsertAsync(studentAndClassroom);
        }

        public async Task DeleteStudentAndClassroomAsync(int id)
        {
            await _studentAndClassroomRepository.DeleteAsync(id);
        }
    }
}
