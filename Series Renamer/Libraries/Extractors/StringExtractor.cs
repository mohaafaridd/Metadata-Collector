using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Series_Renamer.Libraries
{
    public class StringExtractor
    {
        /// <summary>
        /// Extracts a string between two points
        /// </summary>
        /// <param name="strSource">String main source</param>
        /// <param name="strStart">Our Starting Point</param>
        /// <param name="strEnd">Our Ending Point</param>
        /// <returns></returns>
        public static string getBetween(string strSource, string strStart, string strEnd)
        {
            int Start, End;
            if (strSource.Contains(strStart) && strSource.Contains(strEnd))
            {
                Start = strSource.IndexOf(strStart, 0) + strStart.Length;
                End = strSource.IndexOf(strEnd, Start);
                return strSource.Substring(Start, End - Start);
            }
            else
            {
                return "";
            }
        }
    }
}
