using HtmlAgilityPack;
using System.Text;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScheduleApp.Models
{
    internal class ScrapSchedule
    {
        public static string saveToJson()
        {
            string appDirectory = FileSystem.AppDataDirectory;
            string filePath = Path.Combine(appDirectory, "schedule.json");

            string json = JsonConvert.SerializeObject(scheduleList(), Formatting.Indented);

            File.WriteAllText(filePath, json);

            return filePath;
        }

        public static Dictionary<string, string> CreateScheduleTemplate()
        {
            return new Dictionary<string, string>
            {
                { "8:30-9:50",   "" },
                { "10:00-11:20", "" },
                { "11:40-13:00", "" },
                { "13:30-14:50", "" },
                { "15:00-16:20", "" },
                { "16:30-17:50", "" },
                { "18:00-19:20", "" },
            };
        }

        public static Dictionary<string, List<string>> scheduleList()
        {
            var scheduleList = new Dictionary<string, List<string>>
            {
                { "Понеділок 1", new List<string>() },
                { "Вівторок 1", new List<string>() },
                { "Середа 1", new List<string>() },
                { "Четвер 1", new List<string>() },
                { "П'ятниця 1", new List<string>() },

                { "Понеділок 2", new List<string>() },
                { "Вівторок 2", new List<string>() },
                { "Середа 2", new List<string>() },
                { "Четвер 2", new List<string>() },
                { "П'ятниця 2", new List<string>() },
            };

            string url = "https://rozklad.ztu.edu.ua/schedule/group/%D0%86%D0%9F%D0%97-24-3?new";
            var web = new HtmlWeb();

            var document = web.Load(url);
            var docNode = document.DocumentNode;

            var findSchedule = docNode.SelectSingleNode("//table[@class='schedule']");
            var findTd = findSchedule.SelectNodes("//td");

            foreach (var i in findTd)
            {
                var day = i.GetAttributeValue("day", "none");

                var hour = i.GetAttributeValue("hour", "none");

                if (i.GetAttributeValue("class", "") != "")
                {
                    var findSubject = i.SelectNodes(".//div[@class='subject']");
                    string teacher;
                    string subject = "";
                    string[] groups = new string[2];

                    if (findSubject != null)
                    {
                        if (i.SelectSingleNode(".//div[@class='subgroups']") != null)
                        {

                            for (int j = 0; j <= 1; j++)
                            {
                                if (i.SelectNodes(".//div[@class='one']")[j].SelectSingleNode(".//div") != null)
                                {
                                    groups[j] = i.SelectNodes(".//div[@class='one']")[j].SelectSingleNode(".//div").InnerText;
                                }
                            }

                        }
                        else
                        {
                            groups[0] = null;
                            groups[1] = null;
                        }

                        if (findSubject.Count == 1)
                        {
                            if (groups[0] != null)
                                subject = $"{findSubject[0].InnerText}({groups[0]})";

                            else if (groups[1] != null)
                                subject = $"{findSubject[0].InnerText}({groups[1]})";

                            else
                                subject = $"{findSubject[0].InnerText}";
                        }
                        else
                        {
                            if (groups[0] != null && groups[1] != null)
                                subject = $"{findSubject[0].InnerText}({groups[0]})\n   {findSubject[1].InnerText}({groups[1]})";
                            else
                            {
                                for (int j = 0; j <= 1; j++)
                                {
                                    if (groups[j] != null)
                                        subject = $"{findSubject[j].InnerText}({groups[j]})";
                                }
                            }
                        }

                        if (subject == "Іноземна мова")
                            teacher = "Анна Миколаївна";
                        else
                            teacher = i.SelectSingleNode(".//div[@class='teacher']").InnerText;


                        scheduleList[day].AddRange(new List<string> { hour, subject });
                    }

                }

            }

            return scheduleList;
        }
    }
}
