using Common;
using Data.Contracts;
using Entities.Chat;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Data.Repositories.Message
{
    public class ChatRoomService : Repository<ClientChatRoom>, IChatRoomService, IScopedDependency
    {
        public ChatRoomService(ApplicationDbContext context)
            : base(context)
        {

        }

        public async Task<long> CreateChatRoom(string ipAddress, string connectionId)
        {
            var existChatRoom = TableNoTracking.SingleOrDefault(p => p.IPAddress == ipAddress);
            if (existChatRoom != null)
            {
                return await Task.FromResult(existChatRoom.Id);
            }

            ClientChatRoom chatRoom = new ClientChatRoom()
            {
                IPAddress = ipAddress,
                ConnectionId = connectionId
            };
            DbContext.Add(chatRoom);
            DbContext.SaveChanges();
            return await Task.FromResult(chatRoom.Id);
        }

        public async Task<List<long>> GetAllrooms()
        {
            var rooms = Table
                .Include(p => p.ChatMessages)
                .Where(p => p.ChatMessages.Any())
                .Select(p =>
              p.Id).ToList();
            return await Task.FromResult(rooms);
        }

        public async Task<long> GetChatRoomForConnection(string ipAddress)
        {
            var chatRoom = TableNoTracking.SingleOrDefault(p => p.IPAddress == ipAddress);
            return await Task.FromResult(chatRoom.Id);
        }

        public async Task<IList<string>> GetClientMessages(string ipAddress)
        {
            var messages = await TableNoTracking.Include(a => a.ChatMessages).FirstOrDefaultAsync(a => a.IPAddress == ipAddress);

            return messages.ChatMessages.Select(g=>g.Message).ToList();
        }
    }
}
