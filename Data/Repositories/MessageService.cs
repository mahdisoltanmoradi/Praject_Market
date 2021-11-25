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
    public class MessageService : Repository<ChatMessage>,IMessageService, IScopedDependency
    {
        public MessageService(ApplicationDbContext context)
            :base(context)
        {

        }


        public Task<List<MessageDto>> GetChatMessage(Guid RoomId)
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

        public Task SaveChatMessage(Guid RoomId, MessageDto message)
        {
            var room = TableNoTracking.SingleOrDefault(p => p.Id == RoomId).ChatRoom;
            ChatMessage chatMessage = new ChatMessage()
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
