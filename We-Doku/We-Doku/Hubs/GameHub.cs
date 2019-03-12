using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace We_Doku.Hubs
{
    public class GameHub : Hub
    {
        public async Task SendCoordinate(string x, string y, string value)
        {
            int input = Int32.Parse(value);
            if (input < 9 || input > 0)
            {
                await Clients.All.SendAsync("UpdateSpace", x, y, value);
            }

            else
            {

            }
        }
        
    }
}
