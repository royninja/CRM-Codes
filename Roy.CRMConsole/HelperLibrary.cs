using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roy.CRMConsole
{
    public class HelperLibrary
    {
        public static double CalculateBusinessHours(DateTime sdatetime, DateTime edatetime)
        {
            DateTime current = sdatetime;

            double businessHours = 0;

            if(current == edatetime)
            {
                return businessHours;
            }else if (current > edatetime)
            {
                return businessHours;
            }
            else
            {
                while(current < edatetime)
                {
                    if (IsBusinessDay(current))
                    {
                        DateTime workStart = current.Date.AddHours(9);
                        DateTime workEnd = current.Date.AddHours(18);
                        if(current.Day == edatetime.Day)
                        {
                            return 
                        }
                        if (current < workStart)
                        {
                            businessHours = businessHours + (workEnd - workStart).Hours;
                        }
                        else if (current < workEnd)
                        {
                            businessHours = businessHours + (workEnd - current).Hours;
                        }
                    }
                    current = current.AddDays(1).Date;
                }
            }
            return businessHours;
        }

        public static bool IsBusinessDay(DateTime current)
        {
            return current.DayOfWeek != DayOfWeek.Sunday && current.DayOfWeek != DayOfWeek.Saturday;
        }


    }
}
