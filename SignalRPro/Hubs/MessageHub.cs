using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using SignalRPro.Extensions;
using SignalRPro.Extensions.SqlServerNotifier;
using SignalRPro.Models;

namespace SignalRPro.Hubs
{
    public class MessageHub : Hub
    {
        internal NotifierEntity NotifierEntity { get; private set; }
        private MyDbContext db = new MyDbContext();
        public void DispatchToClient()
        {
            Clients.All.broadcastMessage("Refresh");
        }
        

        public void Initialize(String userName)
        {
            if (!string.IsNullOrEmpty(userName))
            {
                NotifierEntity = db.GetNotifierEntity<Messages>(db.Messages.Where(x=>x.ApplicationUser.UserName== userName && !x.Status));
                if (NotifierEntity == null)
                    return;
                Action<String> dispatcher = (t) => { DispatchToClient(); };
                PushSqlDependency.Instance(NotifierEntity, dispatcher);
            }
        }
        
    }
}