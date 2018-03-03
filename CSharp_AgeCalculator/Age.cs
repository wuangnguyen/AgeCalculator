using System;
using System.Text;

namespace AgeCalculator
{
    public class Age
    {
        private int _years;
        private int _months;
        private int _days;
        private DateTime _birtday;
        private DateTime _selectedDate;
        public Age(DateTime birtday)
        {
            Count(birtday);
        }

        public Age(DateTime birtday, DateTime selectedDate)
        {
            Count(birtday, selectedDate);
        }

        public Age Count(DateTime birtday)
        {
            return Count(birtday, DateTime.Today);
        }

        public Age Count(DateTime birtday, DateTime selectedDate)
        {
            _birtday = birtday;
            _selectedDate = selectedDate;

            if (selectedDate.Year - birtday.Year > 0 ||
                selectedDate.Year - birtday.Year == 0 && (birtday.Month < selectedDate.Month ||
                                                            birtday.Month == selectedDate.Month && birtday.Day <= selectedDate.Day))
            {
                int daysInBdayMonth = DateTime.DaysInMonth(birtday.Year, birtday.Month);
                int daysRemain = selectedDate.Day + (daysInBdayMonth - birtday.Day);

                if (selectedDate.Month > birtday.Month)
                {
                    _years = selectedDate.Year - birtday.Year;
                    _months = selectedDate.Month - (birtday.Month + 1) + Math.Abs(daysRemain / daysInBdayMonth);
                    _days = (daysRemain % daysInBdayMonth + daysInBdayMonth) % daysInBdayMonth;
                }
                else if (selectedDate.Month == birtday.Month)
                {
                    if (selectedDate.Day >= birtday.Day)
                    {
                        _years = selectedDate.Year - birtday.Year;
                        _months = 0;
                        _days = selectedDate.Day - birtday.Day;
                    }
                    else
                    {
                        _years = selectedDate.Year - 1 - birtday.Year;
                        _months = 11;
                        _days = DateTime.DaysInMonth(birtday.Year, birtday.Month) - (birtday.Day - selectedDate.Day);
                    }
                }
                else
                {
                    _years = selectedDate.Year - 1 - birtday.Year;
                    _months = selectedDate.Month + (11 - birtday.Month) + Math.Abs(daysRemain / daysInBdayMonth);
                    _days = (daysRemain % daysInBdayMonth + daysInBdayMonth) % daysInBdayMonth;
                }
            }
            else
            {
                throw new ArgumentException("Birthday date must be earlier than current date");
            }
            return this;
        }

        public override string ToString()
        {
            var distances = (_selectedDate - _birtday).Days;
            var sb = new StringBuilder();
            sb.AppendLine($"{_years:N0} year {_months:N0} months {_days:N0} days");
            sb.AppendLine($"or {_years * 12 + _months:N0} months {_days:N0} days");
            sb.AppendLine($"or {distances / 7:N0} weeks {distances % 7:N0} days");
            sb.AppendLine($"or {distances:N0} days");
            sb.AppendLine($"or {distances * 24:N0} hours");
            sb.AppendLine($"or {distances * 24 * 60:N0} minutes");
            sb.AppendLine($"or {distances * 24 * 60 * 60:N0} seconds");
            return sb.ToString();
        }
    }
}
