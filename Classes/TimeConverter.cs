using System;
using System.Text;

namespace BerlinClock
{
    public class TimeConverter : ITimeConverter
    {
        public string convertTime(string aTime)
        {
            if (aTime == null) throw new ArgumentNullException("aTime");

            var outputString = new StringBuilder();

            outputString.AppendLine(YellowLamps(aTime));
            outputString.AppendLine(FiveHoursLamps(aTime));
            outputString.AppendLine(OneHourLamps(aTime));
            outputString.AppendLine(FiveMinutesLamps(aTime));
            outputString.Append(OneMinuteLamps(aTime));

            return outputString.ToString();
        }

        public string YellowLamps(String time)
        {
            if (time == null) throw new ArgumentNullException("time");

            return (getSeconds(time) % 2 == 0) ? "Y" : "O";
        }

        public string FiveHoursLamps(String time)
        {
            if (time == null) throw new ArgumentNullException("time");

            int hours = getHours(time);

            int fiveHourLamps = hours / 5;

            return createLampsString(fiveHourLamps, "RRRR");
        }

        public string OneHourLamps(String time)
        {
            if (time == null) throw new ArgumentNullException("time");

            int hours = getHours(time);

            int oneHourLamps = hours % 5;

            return createLampsString(oneHourLamps, "RRRR");
        }

        public string FiveMinutesLamps(String time)
        {
            if (time == null) throw new ArgumentNullException("time");

            int minutes = getMinutes(time);

            int fiveMinutesLamps = minutes / 5;

            return createLampsString(fiveMinutesLamps, "YYRYYRYYRYY");
        }

        public string OneMinuteLamps(String time)
        {
            if (time == null) throw new ArgumentNullException("time");

            int minutes = getMinutes(time);

            int oneMinuteLamps = minutes % 5;

            return createLampsString(oneMinuteLamps, "YYYY");
        }

        private int getSeconds(String time)
        {
            string[] timeStrings = time.Split(':');

            return Int32.Parse(timeStrings[2]);
        }

        private int getMinutes(String time)
        {
            string[] timeStrings = time.Split(':');

            return Int32.Parse(timeStrings[1]);
        }

        private int getHours(String time)
        {
            string[] timeStrings = time.Split(':');

            return Int32.Parse(timeStrings[0]);
        }

        private string createLampsString(int switchedLamps, String rowLamps)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(rowLamps.Substring(0, switchedLamps));
            sb.Append('O', rowLamps.Length - switchedLamps);

            return sb.ToString();
        }
    }
}
