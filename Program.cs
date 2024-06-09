using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecimaltoBinaryOctalHexa
{
    internal class Program
    {
        static readonly Dictionary<string, int> NumberSet = new Dictionary<string, int>
        {
            { "Binary" , 2 },
            { "Octal",8 },
            { "Hexadecimal",16 }
        };
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Write("Enter a decimal number: ");
                try
                {
                    int decimalNumber = int.Parse(Console.ReadLine());
                    foreach (var item in NumberSet)
                    {
                        Console.WriteLine($"{item.Key} : {ConvertToBase(decimalNumber, item.Value)}");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                Console.ReadKey();
            }
            
        }

        static string ConvertToBase(int number, int toBase)
        {
            if (toBase < 2 || toBase > 16)
            {
                throw new ArgumentException("The base must be between 2 and 16");
            }

            string result = string.Empty;
            string characters = "0123456789ABCDEF";

            bool isNegative = number < 0;
            number = number < 0 ? -number : number;

            do
            {
                int remainder = number % toBase;
                result = characters[remainder] + result;
                number /= toBase;
               
            } while (number > 0);

            return isNegative ? $"-{result}" : result;
        }
    }
}
