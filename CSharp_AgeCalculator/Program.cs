using System;

namespace AgeCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime bday = new DateTime(1991, 06, 21);
            DateTime cday = DateTime.Today;
            Age age = new Age(bday, cday);
            Console.WriteLine(age.ToString());
            Console.ReadLine();
        }
    }
}
