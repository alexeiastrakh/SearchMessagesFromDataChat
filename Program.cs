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
                //Regex regexJava = new Regex(@"(.*)(Java)(.*)");
                //MatchCollection matchesJava = regexJava.Matches(jsonString);

                //List<Java> javaVacancies = new List<Java>();
                //foreach (Match match in matchesJava)
                //{
                //    Java keywordJava = new Java();
                //    keywordJava.JavaVacancy = match.Value;
                //    javaVacancies.Add(keywordJava);
                //}
                //Regex regex = new Regex(@"(.*)(.NET)(.*)");
                //MatchCollection matchesCsharp = regex.Matches(jsonString);

                //List<Csharp> CsharpVacancies = new List<Csharp>();
                //foreach (Match match in matchesCsharp)
                //{
                //    Csharp keyword = new Csharp();
                //    keyword.CsharpVacancy = match.Value;
                //    CsharpVacancies.Add(keyword);
                //}
                //Regex regexPython = new Regex(@"(.*)(Python)(.*)");
                //MatchCollection matchesPython = regex.Matches(jsonString);

                //List<Python> PythonVacancies = new List<Python>();
                //foreach (Match match in matchesPython)
                //{
                //    Python keywordPython = new Python();
                //    keywordPython.PythonVacancy = match.Value;
                //    PythonVacancies.Add(keywordPython);
                //}
                //Regex regexCplusplus = new Regex(@"(.*)(C)(.*)");
                //MatchCollection matchesCplusplus = regex.Matches(jsonString);

                //List<Cplusplus> CplusplusVacancies = new List<Cplusplus>();
                //foreach (Match match in matchesCplusplus)
                //{
                //    Cplusplus keywordCplusplus = new Cplusplus();
                //    keywordCplusplus.CplusplusVacancy = match.Value;
                //    CplusplusVacancies.Add(keywordCplusplus);
                //}

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
                            Regex regexJava = new Regex(@"(.*)(Java)(.*)");
                            MatchCollection matchesJava = regexJava.Matches(jsonString);

                            List<Java> javaVacancies = new List<Java>();
                            foreach (Match match in matchesJava)
                            {
                                Java keywordJava = new Java();
                                keywordJava.JavaVacancy = match.Value;
                                javaVacancies.Add(keywordJava);
                            }
                            Regex regex = new Regex(@"(.*)(.NET)(.*)");
                            MatchCollection matchesCsharp = regex.Matches(jsonString);

                            List<Csharp> CsharpVacancies = new List<Csharp>();
                            foreach (Match match in matchesCsharp)
                            {
                                Csharp keyword = new Csharp();
                                keyword.CsharpVacancy = match.Value;
                                CsharpVacancies.Add(keyword);
                            }
                            Regex regexPython = new Regex(@"(.*)(Python)(.*)");
                            MatchCollection matchesPython = regex.Matches(jsonString);

                            List<Python> PythonVacancies = new List<Python>();
                            foreach (Match match in matchesPython)
                            {
                                Python keywordPython = new Python();
                                keywordPython.PythonVacancy = match.Value;
                                PythonVacancies.Add(keywordPython);
                            }
                            Regex regexCplusplus = new Regex(@"(.*)(C)(.*)");
                            MatchCollection matchesCplusplus = regex.Matches(jsonString);

                            List<Cplusplus> CplusplusVacancies = new List<Cplusplus>();
                            foreach (Match match in matchesCplusplus)
                            {
                                Cplusplus keywordCplusplus = new Cplusplus();
                                keywordCplusplus.CplusplusVacancy = match.Value;
                                CplusplusVacancies.Add(keywordCplusplus);
                            }

                            msgOriginalInstance.javas = javaVacancies;
                            msgOriginalInstance.cplusplus = CplusplusVacancies;
                            msgOriginalInstance.python = PythonVacancies;
                            msgOriginalInstance.csharp = CsharpVacancies;


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
