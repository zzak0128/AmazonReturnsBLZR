using System;
namespace AmazonReturnsInventoryLibrary.Helpers
{
    public class Calc
    {
        public static string MultiplyDoublesAsCurrency(double a, double b)
        {
            double output = a * b;
            return output.ToString("C");
        }

        public static double multiplyDoubles(double a, double b)
        {
            double output = a * b;
            return output;
        }

        public static double AddCurrencies(double income, double expense)
        {
            double output;
            output = income - expense;
            return output;
        }

        public static double FigurePercentage(double partNumber, double totalNumber)
        {
            double output;
            output = partNumber / totalNumber;
            output *= 100;
            return output;
        }
    }
}
