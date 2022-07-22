using Common;
using Data.Contracts;
using Entities.Notification;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class NotificationRepository : INotificationRepository, IScopedDependency
    {
        private readonly ApplicationDbContext _dbContext;

        public NotificationRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Notification>> GetNotifications(string nToUserId, bool bIsGetOnlyUnread)
        {
            int userId = int.Parse(nToUserId);
            var model= await _dbContext.Notifications.Where(n => n.ToUserId == userId).ToListAsync();   
            return model;
        }
    }
}
