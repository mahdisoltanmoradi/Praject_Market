using Entities.Common;

namespace Entities.Notification
{
    public class UserNotification : BaseEntity<int>
    {
        public int UserId { get; set; }
        public int NotificationId { get; set; }
        public User.User User { get; set; }
        public Notification Notification { get; set; }
    }
}
