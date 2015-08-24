using System;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.SignalR;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Data.SqlClient;

namespace SignalRChat
{
    public class ChatHub : Hub
    {
        
        public static List<User> CurrentUsers = new List<User>();
        //SqlConnection db = new SqlConnection();
        public void Send(string name, string message)
        {
            // Call the broadcastMessage method to update clients.
            Clients.All.broadcastMessage(name, message);
            //updatedb();
        }
        public override Task OnDisconnected(bool stopCalled)
        {           
            for(int i=0;i<CurrentUsers.Count;i++)
            {
                if(CurrentUsers[i].ConnectionId == this.Context.ConnectionId)
                {
                    CurrentUsers.RemoveAt(i);
                }
            }
            return base.OnDisconnected(stopCalled);
        }

        public void RegisterUser(String name)
        {
            User newUser = new User(name, this.Context.ConnectionId);
            CurrentUsers.Add(newUser);
            Clients.All.updateUsers(JsonConvert.SerializeObject(CurrentUsers));          
        }

        public Int32 NumberofUsers()
        {
            return CurrentUsers.Count;
        }
        public List<User> SendUserList()
        {
            return CurrentUsers;
        }
    }
}