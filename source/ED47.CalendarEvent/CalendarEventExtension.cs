using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace ED47.CalendarEvent
{
    public static class CalendarEventExtension
    {
        public static int MaxOverlapPercentage(this IEnumerable<ICalendarEvent> events)
        {
            var maxOverlapPercent = 0;

            foreach (var firstEvent in events)
            {
                foreach (var secondEvent in events.Where(el => el != firstEvent))
                {
                    if (firstEvent.StartDate > secondEvent.EndDate)
                        continue;

                    if (firstEvent.EndDate < secondEvent.StartDate)
                        continue;

                    var total = (firstEvent.EndDate - firstEvent.StartDate + (secondEvent.EndDate - secondEvent.StartDate)).Ticks;

                    long overlap;

                    if (firstEvent.StartDate < secondEvent.StartDate)
                        overlap = (firstEvent.EndDate - secondEvent.StartDate).Ticks;
                    else
                        overlap = (secondEvent.EndDate - firstEvent.StartDate).Ticks;

                    var overlapPercent = (int)((float)overlap / (float)total * 100f);

                    if (overlapPercent > maxOverlapPercent)
                        maxOverlapPercent = overlapPercent;

                    if (maxOverlapPercent == 100)
                        return maxOverlapPercent;
                }
            }

            return maxOverlapPercent;
        }

        public static string ToFullCalendarEvents(this IEnumerable<ICalendarEvent> events)
        {
            return JsonConvert.SerializeObject(events.Select(el => new
            {
                title = el.Name,
                start = el.StartDate,
                end = el.EndDate,
                allDay = true,
                url = el.Url
            }), new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore});
        }
    }
}
