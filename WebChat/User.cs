using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SignalRChat
{
    public class User
    {
        public String Name { get; set; }
        public String ConnectionId { get; set; }
        public User(String name, String connectionId)
        {
            this.Name = name;
            this.ConnectionId = connectionId;
        }
    }
}