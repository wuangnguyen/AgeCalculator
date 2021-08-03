using System;

namespace AgeCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime birthDay = new DateTime(1991, 06, 21);
            DateTime selectedDate = DateTime.Today;
            DateDiff dateDiff = new DateDiff(birthDay, selectedDate);
            Console.WriteLine(dateDiff.ToString());
            Console.ReadLine();
        }
    }
}
