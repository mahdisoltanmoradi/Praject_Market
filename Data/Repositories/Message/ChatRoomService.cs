using Common;
using Data.Contracts;
using Entities.Chat;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories.Message
{
    public class ChatRoomService : Repository<ChatRoom>, IChatRoomService, IScopedDependency
    {
        public ChatRoomService(ApplicationDbContext context)
            :base(context)
        {

        }

        public async Task<Guid> CreateChatRoom(string ConnectionId)
        {
            var existChatRoom = TableNoTracking.SingleOrDefault(p => p.ConnectionId == ConnectionId);
            if (existChatRoom != null)
            {
                return await Task.FromResult(existChatRoom.Id);
            }

            ChatRoom chatRoom = new ChatRoom()
            {
                ConnectionId = ConnectionId,
                Id = Guid.NewGuid(),
            };
            DbContext.Add(chatRoom);
            DbContext.SaveChanges();
            return await Task.FromResult(chatRoom.Id);
        }

        public async Task<List<Guid>> GetAllrooms()
        {
            var rooms = Table
                .Include(p => p.ChatMessages)
                .Where(p => p.ChatMessages.Any())
                .Select(p =>
              p.Id).ToList();
            return await Task.FromResult(rooms);
        }

        public async Task<Guid> GetChatRoomForConnection(string CoonectionId)
        {
            var chatRoom = TableNoTracking.SingleOrDefault(p => p.ConnectionId == CoonectionId);
            return await Task.FromResult(chatRoom.Id);
        }
    }
}
