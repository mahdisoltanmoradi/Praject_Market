using Common;
using Data.Contracts;
using Data.DTOs.Message;
using Entities.Chat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class MessageService : Repository<ClientChatMessage>, IMessageService, IScopedDependency
    {
        private ApplicationDbContext _dbContext;
        public MessageService(ApplicationDbContext context)
            : base(context)
        {
            _dbContext = context ?? throw new ArgumentNullException(nameof(context));
        }


        public Task<List<MessageDto>> GetChatMessage(long RoomId)
        {
            var messages = TableNoTracking.Where(p => p.ChatRoomId == RoomId)
                .Select(p => new MessageDto
                {
                    Message = p.Message,
                    Sender = p.Sender,
                    Time = p.Time
                }).OrderBy(p => p.Time).ToList();
            return Task.FromResult(messages);
        }

        public Task SaveChatMessage(long RoomId, MessageDto message)
        {
            var room = DbContext.ClientChatRooms.FirstOrDefault(a => a.Id == RoomId);
            ClientChatMessage chatMessage = new ClientChatMessage()
            {
                ChatRoom = room,
                Message = message.Message,
                Sender = message.Sender,
                Time = message.Time,
            };
            DbContext.Add(chatMessage);
            DbContext.SaveChanges();
            return Task.CompletedTask;
        }
    }
}
