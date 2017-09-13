using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BerlinClock
{
    public class Clock
    {
        private string _hourState = "OOOO";
        private string _fiveHoursState = "OOOO";
        private string _minutesState = "OOOO";
        private string _fiveMinutesState = "OOOOOOOOOOO";

        public string GetSeconds(int seconds)
        {
            return seconds % 2 == 0 ? "Y" : "O";
        }

        public string GetTopHours(int number)
        {
            return GetOnOff(4, GetTopNumberOfOnSigns(number), "R");
        }

        public string GetBottomHours(int number)
        {
            return GetOnOff(4, number % 5, "R");
        }

        public string GetTopMinutes(int number)
        {
            return GetOnOff(11, GetTopNumberOfOnSigns(number), "Y").Replace("YYY", "YYR");
        }

        public string GetBottomMinutes(int number)
        {
            return GetOnOff(4, number % 5, "Y");
        }
        private string GetOnOff(int lamps, int onSigns, string onSign)
        {
            var returnString = "";
            for (var i = 0; i < onSigns; i++)
            {
                returnString += onSign;
            }
            for (var i = 0; i < (lamps - onSigns); i++)
            {
                returnString += "O";
            }
            return returnString;
        }
        private int GetTopNumberOfOnSigns(int number)
        {
            return (number - (number % 5)) / 5;
        }





        public string GetHours(int hours)
        {
            return GetHourRow(hours) + " -- " + GetFiveHoursRow(hours);
        }

        public string GetFiveHoursRow(int hours)
        {
            if (hours == 24)
            {
                _fiveHoursState = "OOOO";
                return _fiveHoursState;
            }

            if (hours % 5 != 0)
                return _fiveHoursState;

            var index = hours / 5;
            _fiveHoursState = _fiveHoursState.Remove(index - 1, 1).Insert(index - 1, "R");

            return _fiveHoursState;
        }

        public string GetHourRow(int hours)
        {
            if (hours % 5 == 0 || hours == 24)
            {
                _hourState = "OOOO";
                return _hourState;
            }

            var index = hours / 5;
            if (hours <= 5)
                index = hours;

            else if (index > 0)
            {
                index = hours - index * 5;
            }

            _hourState = _hourState.Remove(index - 1, 1).Insert(index - 1, "R");

            return _hourState;
        }

        public string GetMinutesRow(int minutes)
        {
            if (minutes % 5 == 0)
            {
                _minutesState = "OOOO";
                return _minutesState;
            }

            var index = minutes / 5;
            if (minutes <= 5)
                index = minutes;

            else if (index > 0)
            {
                index = minutes - index * 5;
            }

            _minutesState = _minutesState.Remove(index - 1, 1).Insert(index - 1, "Y");

            return _minutesState;
        }

        public string GetFiveMinutesRow(int minutes)
        {
            if (minutes == 60)
            {
                _fiveMinutesState = "OOOOOOOOOOO";
                return _fiveMinutesState;
            }

            if (minutes % 5 != 0)
                return _fiveMinutesState;

            var index = minutes / 5;
            var color = "Y";
            if (minutes % 15 == 0)
            {
                color = "R";
            }
            _fiveMinutesState = _fiveMinutesState.Remove(index - 1, 1).Insert(index - 1, color);

            return _fiveMinutesState;
        }

        public string GetMinutes(int minutes)
        {
            return GetFiveMinutesRow(minutes) + " -- " + GetMinutesRow(minutes);
        }
    }
}
