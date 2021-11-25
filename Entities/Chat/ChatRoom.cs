using Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Entities.Chat
{
    public class ChatRoom:BaseEntity<Guid>
    {
        public Guid Id { get; set; }
        public string ConnectionId { get; set; }
        public ICollection<ChatMessage> ChatMessages { get; set; }
    }
}
