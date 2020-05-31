using Abp.Domain.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace triluatsoft.tls.HNH.Students
{
    public interface IStudentManager : IDomainService
    {
        Task<List<Student>> GetAllStudentListAsync();

        Task<Student> GetStudentAsync(int id);

        Task InsertStudentAsync(Student student);

        Task UpdateStudentAsync(Student student);

        Task DeleteStudentAsync(int id);
    }
}
