using System;

namespace ED47.CalendarEvent
{
    interface ICalendarEvent
    {
        string Name { get; set; }
        string Description { get; set; }
        DateTime? StartDate { get; set; }
        DateTime? EndDate { get; set; }
    }
}
