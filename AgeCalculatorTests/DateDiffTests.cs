using AgeCalculator;
using System;
using Xunit;
using static AgeCalculatorTests.DateDiffTestData;

namespace AgeCalculatorTests
{
    public class DateDiffTests
    {
        [Theory]
        [MemberData(nameof(InvalidInputs), MemberType = typeof(DateDiffTestData))]
        public void InvalidInput_ThrowException(DateTime fromDate, DateTime toDate)
        {
            var exception = Assert.Throws<ArgumentException>(() => new DateDiff(fromDate, toDate));
            Assert.Equal("The birthday must be earlier than the selected date.", exception.Message);
        }

        [Theory]
        [MemberData(nameof(ValidInputs), MemberType = typeof(DateDiffTestData))]
        public void ValidInput_Successful(DateTime fromDate, DateTime toDate, DateDiffResult expected)
        {
            var dateDiff = new DateDiff(fromDate, toDate);
            
            Assert.Equal(expected.Years, dateDiff.Years);
            Assert.Equal(expected.Months, dateDiff.Months);
            Assert.Equal(expected.Days, dateDiff.Days);
            Assert.Equal(expected.Distances, dateDiff.Distances);
            Assert.Equal(expected.ToString(), dateDiff.ToString());
        }
    }
}
