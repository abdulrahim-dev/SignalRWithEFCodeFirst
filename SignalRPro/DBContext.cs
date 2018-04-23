using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;
using SignalRPro.Models;

namespace SignalRPro
{
    public class MyDbContext:IdentityDbContext<ApplicationUser>
    {
        public MyDbContext():base("SignalrDBConnection")
        {
            
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public virtual IDbSet<Messages> Messages { get; set; }

        public static MyDbContext Create()
        {
            return new MyDbContext();
        }
    }
}