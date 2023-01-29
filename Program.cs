using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Text;
using System.Text.RegularExpressions;

namespace TelegramSearhMessageBot
{
    class Program
    {
        static void Main(string[] args)
        {
            InsertData();
           
        }

        private static void InsertData()
        {

            using (var context = new Context())
            {

                context.Database.EnsureCreated();
                string jsonString = File.ReadAllText("../../../result.json");
                JObject jsonObject = JObject.Parse(jsonString);
                RootForDatabase objRootForDatabase = JsonConvert.DeserializeObject<RootForDatabase>(jsonString);
                Root objRoot = new Root();
                objRoot.id = objRootForDatabase.id;
                objRoot.name = objRootForDatabase.name;
                objRoot.type = objRootForDatabase.type;
          
                List<Message> msgOriginal = new List<Message>();

                
                foreach (JToken token in jsonObject.SelectTokens("$..[?(@.messages)]"))
                {
                    string jsonStrings = token.ToString();
               
                  
                    List<MessageForDatabase> msgInstanceForDatabase = new List<MessageForDatabase>();
                    
                    msgInstanceForDatabase = objRootForDatabase.messages;
                    if (msgInstanceForDatabase != null)
                    {
                        foreach (MessageForDatabase msg in msgInstanceForDatabase)
                        {
                            Message msgOriginalInstance = new Message();
             
                                msgOriginalInstance.id = msg.id;
                                msgOriginalInstance.text = msg.text.ToString();
                                msgOriginalInstance.type = msg.type;
                                msgOriginalInstance.date = msg.date;
                                msgOriginalInstance.date_unixtime = msg.date_unixtime;                       
                                switch (msg.text.ToString())
                                {
                                case string a when msg.text.ToString().Contains(".NET") : msgOriginalInstance.itDirection = ".NET"; break;
                                case string b when msg.text.ToString().Contains("Java") : msgOriginalInstance.itDirection = "java"; break;
                                case string c when msg.text.ToString().Contains("Python"): msgOriginalInstance.itDirection = "Python"; break;
                                case string d when msg.text.ToString().Contains("C++"): msgOriginalInstance.itDirection = "C++"; break;
                                case string f when msg.text.ToString().Contains("QA"): msgOriginalInstance.itDirection = "QA"; break;
                                case string g when msg.text.ToString().Contains("Manager"): msgOriginalInstance.itDirection = "Manager"; break;
                                default: msgOriginalInstance.itDirection = "Undefined"; break;
                                 }
                                 switch (msg.text.ToString())
                            {
                                case string a when msg.text.ToString().Contains("Junior"): msgOriginalInstance.Expirence = "Junior"; break;
                                case string b when msg.text.ToString().Contains("Junior/Middle"): msgOriginalInstance.Expirence = "Junior/Middle"; break;
                                case string c when msg.text.ToString().Contains("Middle"): msgOriginalInstance.Expirence = "Middle"; break;
                                case string d when msg.text.ToString().Contains("Senior"): msgOriginalInstance.Expirence = "Senior"; break;
                                 default: msgOriginalInstance.Expirence = "Undefined"; break;
                            }
                            msgOriginal.Add(msgOriginalInstance);

                            
                        }
                    }
       
                   
                    
                }

                objRoot.messages = msgOriginal;
                context.Add(objRoot);
                context.SaveChanges();

       
            }
        }

    
    }
}