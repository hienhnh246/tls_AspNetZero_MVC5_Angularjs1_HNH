using Abp.Domain.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace triluatsoft.tls.HNH.Classrooms
{
    public interface IClassroomManager : IDomainService
    {
        Task<List<Classroom>> GetAllClassroomListAsync();

        Task<int> CountTotalAllClassroomAsync();

        Task<Classroom> GetClassroomAsync(int id);

        Task<List<Classroom>> GetClassroomListWithFilterAndPaginationAsync(string filter, int skipCount, int maxResultCount);

        Task InsertClassroomAsync(Classroom classroom);

        Task UpdateClassroomAsync(Classroom classroom);

        Task DeleteClassroomAsync(int id);

        Task ClassroomNotificationAsync(string message);
    }
}
