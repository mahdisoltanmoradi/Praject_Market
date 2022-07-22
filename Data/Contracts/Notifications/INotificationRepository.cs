using Entities.Notification;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data.Contracts
{
    public interface INotificationRepository
    {
        Task<List<Notification>> GetNotifications(string nToUserId,bool bIsGetOnlyUnread);
    }
}
