using Microsoft.AspNet.SignalR;

namespace SignalRPro.Hubs
{
    public class MyFirstHub : Hub
    {
        public void Send(string name, string message)
        {
            // Call the broadcastMessage method to update clients.
            Clients.All.broadcastMessage(name, message);
        }
    }
}