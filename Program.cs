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

                      
                           
                            msgOriginalInstance.type = msg.type;
                            msgOriginalInstance.date = msg.date;
                            msgOriginalInstance.date_unixtime = msg.date_unixtime;                        
                            msgOriginalInstance.text_entities = msg.text_entities;
                            List<ItDirection> directions = new List<ItDirection>();
                            foreach(TextEntity msgEntity in msg.text_entities)
                            {
                                ItDirection itDirection = new ItDirection();
                                switch (msgEntity.text)
                                {
                                    case string a when msgEntity.text.Contains(".NET"): itDirection.direction = ".NET"; break;
                                    case string b when msgEntity.text.Contains("Java"): itDirection.direction = "java"; break;
                                    case string c when msgEntity.text.Contains("Python"): itDirection.direction = "Python"; break;
                                    case string d when msgEntity.text.Contains("C++"): itDirection.direction = "C++"; break;
                                    case string f when msgEntity.text.Contains("QA"): itDirection.direction  = "QA"; break;
                                    case string g when msgEntity.text.Contains("Manager"): itDirection.direction = "Manager"; break;
                                    default: itDirection.direction = "Undefined"; break;
                                }
                             directions.Add(itDirection);
                            }
                      

                            msgOriginalInstance.itDirections = directions;
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
