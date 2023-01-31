using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TelegramSearhMessageBot
{
    public class Message
    {
       
        public int id { get; set; }
        public string type { get; set; }
        public DateTime date { get; set; }
        public string date_unixtime { get; set; }
        public List<TextEntity> text_entities { get; set; }
      
        public List<Java> javas { get; set; }
        public List<Python> python { get; set; }
        public List<Csharp> csharp { get; set; }
        public List<Cplusplus> cplusplus { get; set; }
    }
    public class TextEntity
    {
        public int id { get; set; }
        public string type { get; set; }
        public string text { get; set; }

    }

    public class Java
    {
        public int id;
        public string JavaVacancy;

    }
    public class Python
    {
        public int id;
        public string PythonVacancy;
    }
    public class Csharp
    {
        public int id;
        public string CsharpVacancy;
    }
    public class Cplusplus
    {
        public int id;
        public string CplusplusVacancy;
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
        public List<TextEntity> text_entities { get; set; }

    }

    public class RootForDatabase
    {
        public string name { get; set; }
        public string type { get; set; }
        public int id { get; set; }
        public List<MessageForDatabase> messages { get; set; }
    }

  
}
