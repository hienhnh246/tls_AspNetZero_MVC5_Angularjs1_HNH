using Abp.Collections.Extensions;
using Abp.Domain.Repositories;
using Abp.Extensions;
using Abp.Localization;
using Abp.Notifications;
using Abp.Linq.Extensions;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using triluatsoft.tls.Notifications;

namespace triluatsoft.tls.HNH.Classrooms
{
    public class ClassroomManager : tlsDomainServiceBase, IClassroomManager
    {
        private readonly IRepository<Classroom> _classroomRepository;
        private readonly INotificationPublisher _notificationPublisher;

        public ClassroomManager(IRepository<Classroom> classroomRepository, INotificationPublisher notificationPublisher)
        {
            _classroomRepository = classroomRepository;
            _notificationPublisher = notificationPublisher;
        }

        public async Task<List<Classroom>> GetAllClassroomListAsync()
        {
            var result = await _classroomRepository.GetAllListAsync();

            return result;
        }

        public async Task<int> CountTotalAllClassroomAsync()
        {
            var result = await _classroomRepository.GetAll().CountAsync();

            return result;
        }

        public async Task<List<Classroom>> GetClassroomListWithFilterAndPaginationAsync(string filter, int skipCount, int maxResultCount)
        {
            var result = await _classroomRepository.GetAll()
                //.Include(p => p.ClassroomDetails)
                .WhereIf(!filter.IsNullOrEmpty(), p => p.Name.Contains(filter))
                .OrderBy(p => p.Name)
                .PageBy(skipCount, maxResultCount)
                .ToListAsync();

            return result;
        }

        public async Task<Classroom> GetClassroomAsync(int id)
        {
            var result = await _classroomRepository.GetAsync(id);

            return result;
        }

        public async Task InsertClassroomAsync(Classroom classroom)
        {
            await _classroomRepository.InsertAsync(classroom);
        }

        public async Task UpdateClassroomAsync(Classroom classroom)
        {
            await _classroomRepository.UpdateAsync(classroom);
        }

        public async Task DeleteClassroomAsync(int id)
        {
            await _classroomRepository.DeleteAsync(id);
        }

        public Task ClassroomNotificationAsync(string message)
        {
            //await _notificationPublisher.PublishAsync(
            //   AppNotificationNames.ClassroomNotification,
            //   new MessageNotificationData(LocalizableString(message)),
            //   new LocalizableMessageNotificationData(
            //    new LocalizableString(
            //        "NewTenantRegisteredNotificationMessage",
            //        tlsConsts.LocalizationSourceName
            //        )
            //    ),
            //    severity: NotificationSeverity.Info
            //   );
            throw new System.NotImplementedException();
        }

        private string LocalizableString(string name)
        {
            var result = new LocalizableString(name, tlsConsts.LocalizationSourceName).Localize(new LocalizationContext(LocalizationHelper.Manager));

            return result;
        }
    }
}
