using Entities.Chat;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Data.Contracts
{
    public interface IChatRoomService:IRepository<ClientChatRoom>
    {
        Task<long> CreateChatRoom(string ipAddress, string connectionId);
        Task<long> GetChatRoomForConnection(string ipAddress);
        Task<List<ClientChatRoom>> GetAllRooms();
        Task<IList<string>> GetClientMessages(string ipAddress);
    }

}
