using Data.DTOs.Message;
using Entities.Chat;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data.Contracts
{
    public interface IMessageService : IRepository<ClientChatMessage>
    {
        Task SaveChatMessage(long RoomId, MessageDto message);
        Task<List<MessageDto>> GetChatMessage(long RoomId);
    }

}
