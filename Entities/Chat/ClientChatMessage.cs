using Entities.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Entities.Chat
{
    public class ClientChatMessage : BaseEntity<long>
    {
        public string Sender { get; set; }
        public string Message { get; set; }
        public DateTime Time { get; set; }
        public ClientChatRoom ChatRoom { get; set; }
        public long ChatRoomId { get; set; }
    }

    public class ChatMessageConfig : IEntityTypeConfiguration<ClientChatMessage>
    {
        public void Configure(EntityTypeBuilder<ClientChatMessage> builder)
        {
            builder.HasKey(a => a.Id);
        }
    }
}
