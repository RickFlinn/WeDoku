using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace We_Doku.Hubs
{
    public class ChatHub : Hub
    {

        /// <summary>
        /// This method handles chat hub for chat razor page only
        /// </summary>
        /// <param name="user">user who sent message</param>
        /// <param name="message">message to display</param>
        /// <returns>signal R method call</returns>
        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }
    }
}
