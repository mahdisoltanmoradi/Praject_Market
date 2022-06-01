using Data.Contracts;
using Data.DTOs.Message;
using Entities.Chat;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace SignalR.Bugeto.Hubs
{
    public class SiteChatHub : Hub
    {
        private readonly IChatRoomService _chatRoomService;
        private readonly IMessageService _messageService;
        private readonly IRepository<ClientChatRoom> _repository;
        public SiteChatHub(IChatRoomService chatRoomService, IMessageService messageService, IRepository<ClientChatRoom> repository)
        {
            _chatRoomService = chatRoomService;
            _messageService = messageService;
            _repository = repository;
        }

        public async Task SendNewMessage(string Sender, string Message)
        {
            string host = Dns.GetHostName();
            // Getting ip address using host name
            IPHostEntry entryHost = Dns.GetHostEntry(host);

            string ip = entryHost.AddressList[3].ToString();

            var roomId = await _chatRoomService.GetChatRoomForConnection(ip);

            MessageDto messageDto = new MessageDto()
            {
                Message = Message,
                Sender = Sender,
                Time = DateTime.Now,
            };

            await _messageService.SaveChatMessage(roomId, messageDto);
            await Clients.Groups(roomId.ToString())
                .SendAsync("getNewMessage", messageDto.Sender, messageDto.Message, messageDto.Time.ToShortDateString());
        }

        /// <summary>
        /// پیوستن پشتیبان ها به گروه
        /// </summary>
        /// <param name="roomId"></param>
        /// <returns></returns>
        /// 
        public async Task JoinRoom(string roomId)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, roomId);
        }

        /// <summary>
        /// ترک گروه توسط پشتیبان
        /// </summary>
        /// <param name="roomId"></param>
        /// <returns></returns>
        public async Task LeaveRoom(string roomId)
        {
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, roomId);
        }


        public override async Task OnConnectedAsync()
        {
            //if (Context.User.Identity.IsAuthenticated)
            //{
            //    await base.OnConnectedAsync();
            //    return;
            //}

            string host = Dns.GetHostName();
            // Getting ip address using host name
            IPHostEntry entryHost = Dns.GetHostEntry(host);

            string ip = entryHost.AddressList[3].ToString();

            var roomId = await _chatRoomService.CreateChatRoom(ip, Context.ConnectionId);

            await Groups.AddToGroupAsync(Context.ConnectionId, roomId.ToString());
            await Clients.Caller.
                SendAsync("getNewMessage", "سلام وقت بخیر 👋 . چطور میتونم کمکتون کنم؟", DateTime.Now.ToShortTimeString());

            var msgs = await _chatRoomService.GetClientMessages(ip);

            if (msgs is not null)
                await Clients.Caller.
                    SendAsync("GetOlderMessages", msgs);

            await base.OnConnectedAsync();
        }

        public override Task OnDisconnectedAsync(Exception exception)
        {
            return base.OnDisconnectedAsync(exception);
        }
    }
}
