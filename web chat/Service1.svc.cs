using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace web_chat
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        DataContext db = new DataContext();
        public List<Chat> GetAllChat()
        {
            return db.Chats.ToList();
        }

        public List<Chat> GetChatAfterId(int Id)
        {
            return db.Chats.Where(c => c.Id > Id).ToList();
        }

        public bool Login(string Username, string Password)
        {
            return db.Accounts.Any(a => a.Username.Equals(Username) && a.Password.Equals(Password));
        }

        public bool Register(string Username, string Password)
        {
            if (string.IsNullOrEmpty(Username) || string.IsNullOrEmpty(Password))
            {
                return false;
            }
            else if (db.Accounts.Any(a => a.Username.Equals(Username)))
            {
                return false;
            }
            else
            {
                try
                {
                    db.Accounts.Add(new Account() { Username = Username, Password = Password });
                    db.SaveChanges();
                    return true;
                }
                catch { return false; }
            }
        }

        public bool SendMessage(string Content, string Sender)
        {
            if (string.IsNullOrEmpty(Content) || string.IsNullOrEmpty(Sender))
            {
                return false;
            }
            else if (!db.Accounts.Any(a => a.Username.Equals(Sender)))
            {
                return false;
            }
            else
            {
                try
                {
                    db.Chats.Add(new Chat() { Content = Content, Sender = Sender, SentTime = DateTime.Now });
                    db.SaveChanges();
                    return true;
                }
                catch { return false; }
            }
        }
    }
}
