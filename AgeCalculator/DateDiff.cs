using System;
using System.Text;

namespace AgeCalculator
{
    public struct DateDiff
    {
        private int years;
        private int months;
        private int days;
        private readonly int distances;

        public int Years
        {
            get { return years; }
        }

        public int Months
        {
            get { return months; }
        }

        public int Days
        {
            get { return days; }
        }

        public int Distances
        {
            get { return distances; }
        }
        public DateDiff(DateTime birthday, DateTime selectedDate)
        {
            distances = (selectedDate - birthday).Days;
            years = months = days = 0;
            Calcualte(birthday, selectedDate);
        }

        private bool IsFromDateGreaterThanToDate(DateTime fromDate, DateTime toDate)
        {
            return toDate.Year - fromDate.Year == 0 && (fromDate.Month > toDate.Month || fromDate.Month == toDate.Month && fromDate.Day >= toDate.Day);
        }
        private void Calcualte(DateTime fromDate, DateTime toDate)
        {
            if (toDate.Year - fromDate.Year <= 0 || IsFromDateGreaterThanToDate(fromDate, toDate))
            {
                throw new ArgumentException("The birthday must be earlier than the selected date.");
            }

            int daysInMonth = DateTime.DaysInMonth(fromDate.Year, fromDate.Month);
            int remainingDays = toDate.Day + (daysInMonth - fromDate.Day);

            if (toDate.Month > fromDate.Month)
            {
                years = toDate.Year - fromDate.Year;
                months = toDate.Month - (fromDate.Month + 1) + Math.Abs(remainingDays / daysInMonth);
                days = (remainingDays % daysInMonth + daysInMonth) % daysInMonth;
            }
            else if (toDate.Month == fromDate.Month)
            {
                if (toDate.Day >= fromDate.Day)
                {
                    years = toDate.Year - fromDate.Year;
                    months = 0;
                    days = toDate.Day - fromDate.Day;
                }
                else
                {
                    years = toDate.Year - 1 - fromDate.Year;
                    months = 11;
                    days = DateTime.DaysInMonth(fromDate.Year, fromDate.Month) - (fromDate.Day - toDate.Day);
                }
            }
            else
            {
                years = toDate.Year - 1 - fromDate.Year;
                months = toDate.Month + (11 - fromDate.Month) + Math.Abs(remainingDays / daysInMonth);
                days = (remainingDays % daysInMonth + daysInMonth) % daysInMonth;
            }
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"{years:N0} year {months:N0} months {days:N0} days");
            sb.AppendLine($"or {years * 12 + months:N0} months {days:N0} days");
            sb.AppendLine($"or {distances / 7:N0} weeks {distances % 7:N0} days");
            sb.AppendLine($"or {distances:N0} days");
            sb.AppendLine($"or {distances * 24:N0} hours");
            sb.AppendLine($"or {distances * 24 * 60:N0} minutes");
            sb.AppendLine($"or {distances * 24 * 60 * 60:N0} seconds");
            return sb.ToString();
        }
    }
}
