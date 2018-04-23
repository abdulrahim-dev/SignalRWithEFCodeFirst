using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SignalRPro.Models
{
    public class Messages: BaseEntity
    {
        public int Id { get; set; }

        public string Message { get; set; }

        public bool Status { get; set; }

        public string ApplicationUserId { get; set; }

        //[ForeignKey("ApplicationUserId")]
        public virtual ApplicationUser ApplicationUser { get; set; }


    }
}