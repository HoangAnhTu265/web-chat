using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace web_chat
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {

       

        // TODO: Add your service operations here

        [OperationContract]
        bool Login(string Username, string Password);

        [OperationContract]
        bool Register(string Username, string Password);

        [OperationContract]
        bool SendMessage(string Content, string Sender);

        [OperationContract]
        List<Chat> GetAllChat();

        [OperationContract]
        List<Chat> GetChatAfterId(int Id);
    }


    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    [DataContract]
    public class CompositeType
    {
        bool boolValue = true;
        string stringValue = "Hello ";

        [DataMember]
        public bool BoolValue
        {
            get { return boolValue; }
            set { boolValue = value; }
        }

        [DataMember]
        public string StringValue
        {
            get { return stringValue; }
            set { stringValue = value; }
        }
    }
}
