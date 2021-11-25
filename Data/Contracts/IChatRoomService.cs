using Entities.Chat;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Data.Contracts
{
    public interface IChatRoomService:IRepository<ChatRoom>
    {
        Task<Guid> CreateChatRoom(string ConnectionId);
        Task<Guid> GetChatRoomForConnection(string CoonectionId);
        Task<List<Guid>> GetAllrooms();
    }

}
