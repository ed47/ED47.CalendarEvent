using System.Collections.Generic;

namespace ED47.CalendarEvent
{
    interface ICalendarEventRepository
    {
        IEnumerable<TCalendarEvent> GetByOwner<TCalendarEvent>(string ownerId)
            where TCalendarEvent : ICalendarEvent, new();

        IEnumerable<TCalendarEvent> GetByTarget<TCalendarEvent>(string targetId)
            where TCalendarEvent : ICalendarEvent, new();
        
        TCalendarEvent Get<TCalendarEvent>(int id)
            where TCalendarEvent : ICalendarEvent, new();

        ICalendarEvent Get(int id);

        bool Delete(int id);
        bool DeleteByOwner(string ownerId);
        bool DeleteByTarget(string ownerId);
    }
}
