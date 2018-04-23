using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SignalRPro.Models;

namespace SignalRPro.Repository
{
    public class GetMessages
    {
        MyDbContext _context =new MyDbContext();

        public List<Messages> GetMessage()
        {
            return _context.Messages.ToList();
        }
    }
}