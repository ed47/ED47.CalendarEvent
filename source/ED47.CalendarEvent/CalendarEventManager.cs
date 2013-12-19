using Ninject;

namespace ED47.CalendarEvent
{
    class CalendarEventManager
    {
        private static IKernel _kernel;
        public static IKernel Kernel
        {
            get
            {
                return _kernel ?? (_kernel = new StandardKernel());
            }
            set
            {
                _kernel = value;
            }
        }

        private static ICalendarEventRepository _repository;
        public static ICalendarEventRepository Repository
        {
            get
            {
                return _repository ?? (_repository = Kernel.Get<ICalendarEventRepository>());
            }
        }
    }
}
