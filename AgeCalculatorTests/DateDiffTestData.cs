using System;
using System.Collections.Generic;
using System.Text;

namespace AgeCalculatorTests
{
    public class DateDiffTestData
    {
        public struct DateDiffResult
        {
            public int Years { get; set; }
            public int Months { get; set; }
            public int Days { get; set; }
            public int Distances { get; set; }
            public override string ToString()
            {
                var sb = new StringBuilder();
                sb.AppendLine($"{Years:N0} year {Months:N0} months {Days:N0} days");
                sb.AppendLine($"or {Years * 12 + Months:N0} months {Days:N0} days");
                sb.AppendLine($"or {Distances / 7:N0} weeks {Distances % 7:N0} days");
                sb.AppendLine($"or {Distances:N0} days");
                sb.AppendLine($"or {Distances * 24:N0} hours");
                sb.AppendLine($"or {Distances * 24 * 60:N0} minutes");
                sb.AppendLine($"or {Distances * 24 * 60 * 60:N0} seconds");
                return sb.ToString();
            }
        }
        public static IEnumerable<object[]> InvalidInputs =>
        new List<object[]>
        {
            new object[] { DateTime.Now, DateTime.Now },
            new object[] { DateTime.Now, DateTime.Now.AddDays(-2) },
            new object[] { DateTime.Now, DateTime.Now.AddMonths(-1) },
            new object[] { DateTime.Now, DateTime.Now.AddYears(-1) }
        };
        public static IEnumerable<object[]> ValidInputs =>
        new List<object[]>
        {
            new object[] {
                new DateTime(1995, 3, 10),
                new DateTime(2020, 10, 3),
                new DateDiffResult {
                    Years = 25,
                    Months = 6,
                    Days = 24,
                    Distances = (new DateTime(2020, 10, 3) - new DateTime(1995, 3, 10)).Days
                }
            },
            new object[] {
                new DateTime(1950, 9, 13),
                new DateTime(2020, 6, 29),
                new DateDiffResult {
                    Years = 69,
                    Months = 9,
                    Days = 16,
                    Distances = (new DateTime(2020, 6, 29) - new DateTime(1950, 9, 13)).Days
                }
            },
            new object[] {
                new DateTime(1985, 12, 9),
                new DateTime(2015, 11, 15),
                new DateDiffResult {
                    Years = 29,
                    Months = 11,
                    Days = 6,
                    Distances = (new DateTime(2015, 11, 15) - new DateTime(1985, 12, 9)).Days
                }
            }
        };
    }
}
