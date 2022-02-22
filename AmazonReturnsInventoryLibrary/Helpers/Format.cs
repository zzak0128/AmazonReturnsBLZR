using System;
namespace AmazonReturnsInventoryLibrary.Helpers
{
    public class Format
    {
        public static string AsCurrency(double input)
        {
            return input.ToString("C");
        }
    }
}
