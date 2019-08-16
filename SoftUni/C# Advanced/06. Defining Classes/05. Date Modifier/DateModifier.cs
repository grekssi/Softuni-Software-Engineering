using System;
using System.Collections.Generic;
using System.Text;

namespace classesDateModifier
{
    public class DateModifier
    {
        private DateTime startDate;
        private DateTime endDate;

        public DateTime StartDate
        {
            get { return this.startDate; }
            set { this.startDate = value; }
        }

        public DateTime EndDate
        {
            get { return this.endDate; }
            set { this.endDate = value; }
        }

        public int getDays(DateTime startDate, DateTime endDate)
        {
            TimeSpan days = endDate - startDate;
            int totaldays = days.Days;
            if (totaldays >= 0)
            {
                return days.Days;
            }
            else
            {
                return days.Days * -1;
            }
          
        }
    }
}
