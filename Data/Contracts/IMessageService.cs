using Data.Contracts;
using Data.DTOs.Message;
using Entities.Chat;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data.Contracts
{
    public interface IMessageService:IRepository<ChatMessage>
    {
        Task SaveChatMessage(Guid RoomId, MessageDto message);
        Task<List<MessageDto>> GetChatMessage(Guid RoomId);
    }

}
