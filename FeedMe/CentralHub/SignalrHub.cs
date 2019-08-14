using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace FeedMe.CentralHub
{
    public class SignalrHub
    {

    }

    public async Task BroadcastMessage()
    {
        await Clients.All.SendAsync("Connected");
    }


}
