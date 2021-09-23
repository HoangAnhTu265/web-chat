using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
namespace web_chat
{
    public class DataInitializer : DropCreateDatabaseIfModelChanges<DataContext>
    {
        protected override void Seed(DataContext context)
        {
            context.Accounts.Add(new Account() { Username = "admin", Password = "admin" });
            context.Accounts.Add(new Account() { Username = "user", Password = "user" });
            context.Accounts.Add(new Account() { Username = "user1", Password = "user1" });
            context.Accounts.Add(new Account() { Username = "DuyLy", Password = "duyly" });

            context.Chats.AddRange(new List<Chat>() {
                new Chat() { Id = 1,Sender = "admin",Content = "Hello World",SentTime = DateTime.Now},
                new Chat() { Id = 2, Sender = "user1", Content = "Hi ", SentTime = DateTime.Now.AddSeconds(10)},
                new Chat() { Id = 3, Sender = "user", Content = "How are you", SentTime = DateTime.Now.AddSeconds(12) },
                new Chat() { Id = 4, Sender = "user1", Content = "fine", SentTime = DateTime.Now.AddSeconds(14) },

            });
            context.SaveChanges();
            base.Seed(context);
        }
    }
}