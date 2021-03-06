﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookCheckInCheckOut.Web.Core
{
    public static class ExtensionMethods
    {

        private static List<DayOfWeek> _lstWeekEnds = null;
        private static List<DayOfWeek> lstWeekEnds
        {
            get
            {
                if(_lstWeekEnds == null)
                {
                    _lstWeekEnds = new List<DayOfWeek>() {
                        DayOfWeek.Saturday
                        , DayOfWeek.Sunday
                    };
                }
                return _lstWeekEnds;
            }
        }
        public static DateTime AddBusinessDays(this DateTime current, int days)
        {
            var sign = Math.Sign(days);
            var unsignedDays = Math.Abs(days);
            for (var i = 0; i < unsignedDays; i++)
            {
                do
                {
                    current = current.AddDays(sign);
                } while (current.DayOfWeek == DayOfWeek.Saturday ||
                         current.DayOfWeek == DayOfWeek.Sunday);
            }
            return current;
        }

        public static int BusinessDaysUntil(this DateTime firstDay, DateTime lastDay)
        {
            firstDay = firstDay.Date;
            lastDay = lastDay.Date;
            if (firstDay > lastDay)
                throw new ArgumentException("Incorrect last day " + lastDay);

            TimeSpan span = lastDay - firstDay;
            int businessDays = span.Days + 1;
            int fullWeekCount = businessDays / 7;
            // find out if there are weekends during the time exceedng the full weeks
            if (businessDays > fullWeekCount * 7)
            {
                // we are here to find out if there is a 1-day or 2-days weekend
                // in the time interval remaining after subtracting the complete weeks
                int firstDayOfWeek = (int)firstDay.DayOfWeek;
                int lastDayOfWeek = (int)lastDay.DayOfWeek;
                if (lastDayOfWeek < firstDayOfWeek)
                    lastDayOfWeek += 7;
                if (firstDayOfWeek <= 6)
                {
                    if (lastDayOfWeek >= 7)// Both Saturday and Sunday are in the remaining time interval
                        businessDays -= 2;
                    else if (lastDayOfWeek >= 6)// Only Saturday is in the remaining time interval
                        businessDays -= 1;
                }
                else if (firstDayOfWeek <= 7 && lastDayOfWeek >= 7)// Only Sunday is in the remaining time interval
                    businessDays -= 1;
            }
            businessDays -= fullWeekCount + fullWeekCount;

            return businessDays;
        }

        public static DateTime BusinessDays(this DateTime currentDate, int iDays)
        {
            int unSigned = Math.Abs(iDays);
            int iCount = 0;
            
            while (iCount < iDays)
            {
                currentDate = currentDate.AddDays(1);
                DayOfWeek currentDay = currentDate.DayOfWeek;
                if(!lstWeekEnds.Contains(currentDay))
                {
                    iCount++;
                }
                
            }
            return currentDate;
        }

        public static int CountBusinessDaysFrom(this DateTime fromDate, DateTime toDate)
        {
            int iCount = 0;
            if(toDate > fromDate)
            {
                double iTotalDays = (toDate - fromDate).TotalDays;
                if(iTotalDays > 0)
                {
                    while(fromDate <= toDate)
                    {
                        DayOfWeek currenDay = fromDate.DayOfWeek;
                        if(!lstWeekEnds.Contains(currenDay))
                        {
                            iCount++;
                        }
                        fromDate = fromDate.AddDays(1);
                    }
                }
            }
            return iCount;
        }
    }
}