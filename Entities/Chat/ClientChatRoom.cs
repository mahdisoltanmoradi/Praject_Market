using Entities.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Collections.Generic;

namespace Entities.Chat
{
    public class ClientChatRoom : BaseEntity<long>
    {
        public string ConnectionId { get; set; }
        public string IPAddress { get; set; }
        public string Name { get; set; } // اضافه شد
        public ICollection<ClientChatMessage> ChatMessages { get; set; }
    }

    public class ChatRoomConfig : IEntityTypeConfiguration<ClientChatRoom>
    {
        public void Configure(EntityTypeBuilder<ClientChatRoom> builder)
        {
            builder.HasKey(a => a.Id);
        }
    }
}
