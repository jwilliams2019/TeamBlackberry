using System;

namespace BerylCalendar.Utilities{
    public class DateTimeUtilities{
        
        //combines the date of the first object with the time of the second
        public static DateTime CombineDateTime(DateTime date, DateTime time){
            date = date.Date.Add(time.TimeOfDay);
            return date;
        }
    }
}