using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace TelegramSearhMessageBot
{
    public class Message
    {
        public int id { get; set; }
        public string type { get; set; }
        public DateTime date { get; set; }
        public string date_unixtime { get; set; }
        public string text { get; set; }
        public string itDirection { get; set; }
        public string Expirence { get; set; }
    }

    public class Root
    {
        public string? name { get; set; }
        public string type { get; set; }
        public int id { get; set; }
        public List<Message> messages { get; set; }
    }


    public class MessageForDatabase
    {
        public int id { get; set; }
        public string type { get; set; }
        public DateTime date { get; set; }
        public string date_unixtime { get; set; }
        public object text { get; set; }
     

    }

    public class RootForDatabase
    {
        public string name { get; set; }
        public string type { get; set; }
        public int id { get; set; }
        public List<MessageForDatabase> messages { get; set; }
    }

  
}
