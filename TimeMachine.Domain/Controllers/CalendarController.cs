using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeMachine.Service.Agents;

namespace TimeMachine.Domain.Controllers
{
    public class CalendarController
    {

        #region Constants

        #endregion

        #region Fields
        private GoogleCalendarAgent agent = default(GoogleCalendarAgent);
        #endregion

        #region Properties
        /// <summary>
        /// the total free time i have at the calendar.
        /// </summary>
        public double TotalFreeTime
        {
            get
            {
                return agent.TotalFreeTime;
            }
        }

        #endregion

        #region Constructors

        #endregion

        #region Private Functions

        #endregion

        #region Methods
        public double GetTimeSpaceByCalendar(int calendarIndex)
        {

            return 0.0;
        }

        public void Clear()
        {
            //TODO: remove resources
        }

        #endregion
    }
}
