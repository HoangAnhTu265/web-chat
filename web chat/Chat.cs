using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace web_chat
{
    public class Chat
    {
        public int Id { get; set; }

        public string Content{ get; set; }

        public string Sender { get; set; }

        public DateTime SentTime { get; set; }

        public virtual Account Accounts { get; set; }
    }
}