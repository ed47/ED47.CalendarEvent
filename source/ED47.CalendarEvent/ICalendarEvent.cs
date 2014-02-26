using System;

namespace ED47.CalendarEvent
{
    public interface ICalendarEvent
    {
        string Name { get; set; }
        string Description { get; set; }
        DateTime StartDate { get; set; }
        DateTime EndDate { get; set; }
        bool AllDay { get; set; }
        string Url { get; set; }
    }
}
