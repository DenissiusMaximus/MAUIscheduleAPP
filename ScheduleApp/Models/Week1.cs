using System.Collections.ObjectModel;
using System.Diagnostics;

namespace ScheduleApp.Models
{
    public class Week1
    {

        public ObservableCollection<DaySchedule> Days { get; set; } = new ObservableCollection<DaySchedule>();

        public Week1() =>
            LoadData();


        public void LoadData()
            {
                Days.Clear();

                string[] daysList = { "Понеділок 1", "Вівторок 1", "Середа 1", "Четвер 1", "П'ятниця 1" };

                foreach (var day in daysList)
                {
                    var subjDict = ScrapSchedule.getDic(day);
                    var scheduleItems = new ObservableCollection<ScheduleItem>();
                    foreach (var item in subjDict) 
                    {
                        if (item.Value != "")
                        {
                            scheduleItems.Add(new ScheduleItem { Time = item.Key, Subject = item.Value });
                    }
                    }

                    Days.Add(new DaySchedule { Day = day.Substring(0, day.Length-2), ScheduleItems = scheduleItems });
                }

        }
    }

    public class DaySchedule
    {
        public string Day { get; set; }
        public ObservableCollection<ScheduleItem> ScheduleItems { get; set; }
    }

    public class ScheduleItem
    {
        public string Time { get; set; }
        public string Subject { get; set; }
    }
}
