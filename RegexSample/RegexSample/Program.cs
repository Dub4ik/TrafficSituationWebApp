using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace RegexSample
{
    class Program
    {
        static void Main(string[] args)
        {
            //string input = "[50.50,60.60][40.40,55.55]";
            //string pattern = @"\[(\d+.\d+)[^\d](\d+.\d+)\]"; //подвох с запятой. Разделитель зависит от CurrentCulture
            //foreach (Match item in Regex.Matches(input, pattern))
            //{
            //    Console.WriteLine("Долгота {0} : Широта {1}", item.Groups[1].Value, item.Groups[2].Value );
            //}
            string test = "racqwecar";

            Console.WriteLine("{0} - {1}",test,IsPalindrom(test));

            Console.ReadKey();
        }

        static bool IsPalindrom(string stringToTest)
        {
            int start = 0, end;

            if (stringToTest.Length==0)
            {
                throw new Exception();
            }

            stringToTest = stringToTest.ToLower().Replace(" ",String.Empty);

            end = stringToTest.Length - 1;

            while (start<end)
            {
                if (stringToTest[start]!=stringToTest[end])
                {
                    return false;
                }
                else
                {
                    start++;
                    end--;
                }
            }

            return true;
        }
    }
}
