using Abp.Domain.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace triluatsoft.tls.HNH.Students
{
    public class StudentManager : tlsDomainServiceBase, IStudentManager
    {
        private readonly IRepository<Student> _studentRepository;

        public StudentManager(IRepository<Student> studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public async Task<List<Student>> GetAllStudentListAsync()
        {
            var result = await _studentRepository.GetAllListAsync();

            return result;
        }

        public async Task<Student> GetStudentAsync(int id)
        {
            var result = await _studentRepository.GetAsync(id);

            return result;
        }

        public async Task InsertStudentAsync(Student student)
        {
            await _studentRepository.InsertAsync(student);
        }

        public async Task UpdateStudentAsync(Student student)
        {
            await _studentRepository.UpdateAsync(student);
        }

        public async Task DeleteStudentAsync(int id)
        {
            await _studentRepository.DeleteAsync(id);
        }
    }
}
