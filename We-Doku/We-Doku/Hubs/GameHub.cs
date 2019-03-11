using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace We_Doku.Hubs
{
    public class GameHub : Hub
    {
        public async Task SendCoordinate(string x, string y)
        {
            await Clients.All.SendAsync("UpdateSpace", x, y);
        }
    }
}
