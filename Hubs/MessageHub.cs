using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace AspNetCoreSignalR.Hubs
{
    public class MessageHub : Hub
    {
        public Task SendMessageToAll(string message)
        {
            return Clients.All.SendAsync("ReceiveMessage", message);
        }
    }
}