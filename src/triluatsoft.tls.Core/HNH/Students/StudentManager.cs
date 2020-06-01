using Abp.Collections.Extensions;
using Abp.Domain.Repositories;
using Abp.Extensions;
using Abp.Linq.Extensions;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using triluatsoft.tls.HNH.StudentsAndClassrooms;

namespace triluatsoft.tls.HNH.Students
{
    public class StudentManager : tlsDomainServiceBase, IStudentManager
    {
        private readonly IRepository<Student> _studentRepository;
        private readonly IRepository<StudentAndClassroom> _studentAndClassroomRepository;

        public StudentManager(IRepository<Student> studentRepository, IRepository<StudentAndClassroom> studentAndClassroomRepository)
        {
            _studentRepository = studentRepository;
            _studentAndClassroomRepository = studentAndClassroomRepository;
        }

        public async Task<List<Student>> GetAllStudentListAsync()
        {
            var result = await _studentRepository.GetAllListAsync();

            return result;
        }

        public async Task<int> CountTotalAllStudentAsync()
        {
            var result = await _studentRepository.GetAll().CountAsync();

            return result;
        }

        public async Task<List<Student>> GetStudentListWithFilterAndPaginationAsync(string filter, int skipCount, int maxResultCount)
        {
            var result = await _studentRepository.GetAll()
                .WhereIf(
                    !filter.IsNullOrEmpty(),
                    p => p.Name.Contains(filter) ||
                            p.Surname.Contains(filter) ||
                            p.EmailAddress.Contains(filter))
                .OrderBy(p => p.Name)
                .PageBy(skipCount, maxResultCount)
                .ToListAsync();

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

        public async Task<List<Student>> GetStudentsInClassroom(int classroomId)
        {
            List<Student> result = new List<Student>();

            var query = _studentRepository.GetAll().Join(
                _studentAndClassroomRepository.GetAll().Where(studentAndClassroom => studentAndClassroom.ClassroomId == classroomId),
                student => student.Id,
                studentAndClassroom => studentAndClassroom.StudentId, (student, studentAndClassroom) => new { student }
                );

            var items = await query.ToListAsync();

            foreach (var item in items)
            {
                result.Add(item.student);
            }

            return result;
        }

        //public async Task<List<Student>> GetStudentsInClassroom2(int classroomId)
        //{
        //    var query = from s in _studentRepository.GetAll()
        //                join cd in _studentAndClassroomRepository.GetAll() on s.Id equals cd.StudentId
        //                where cd.ClassroomId == classroomId
        //                select new { s, cd };

        //    var items = await query.ToListAsync();

        //    var result = new List<Student>(items.Select(item =>
        //    {
        //        var dto = item.s.MapTo<Student>();
        //        return dto;
        //    }).ToList());

        //    return result;
        //}
    }
}
