using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewBackendSolution
{
    internal class Program
    {
        private static int input;
        private static bool mustAskForInput = true;

        static void Main(string[] args)
        {
            if (args.Length > 0)
            {
                mustAskForInput = !int.TryParse(args[0], out input);
            }

            if (mustAskForInput)
            {
                input = AskForInput();
            }

            string output = "";

            for(int i = 0; i < 4; i++) 
            {
                switch (i)
                {
                    case 0:
                        output += ConvertToRomanNumeric(input / 1000, "M", "", "");
                        break;
                    case 1:
                        output += ConvertToRomanNumeric(input / 100 % 10, "C", "D", "M");
                        break;
                    case 2:
                        output += ConvertToRomanNumeric(input / 10 % 10, "X", "L", "C");
                        break;
                    case 3:
                        output += ConvertToRomanNumeric(input % 10, "I", "V", "X");                       
                        break;
                }
            }
            Console.WriteLine(output);
            Console.ReadKey();
        }

        private static string ConvertToRomanNumeric(int arabicDigit, string a, string b, string c)
        {
            string romanDigit = "";

            switch (arabicDigit)
            {
                case 1:
                    romanDigit = a;
                    break;

                case 2:
                    romanDigit = a + a;
                    break;

                case 3:
                    romanDigit = a + a + a;
                    break;

                case 4:
                    romanDigit = a + b;
                    break;

                case 5:
                    romanDigit = b;
                    break;

                case 6:
                    romanDigit = b + a;
                    break;

                case 7:
                    romanDigit = b + a + a;
                    break;

                case 8:
                    romanDigit = b + a + a + a;
                    break;

                case 9: 
                    romanDigit = a + c;
                    break;

            }

            return romanDigit;
        }

        private static int AskForInput(bool showError = false)
        {
            Console.Clear();
            if (showError)
            {
                Console.WriteLine("Your input is invalid!");
            }

            Console.WriteLine("Please enter a number between 1 and 3999");
            var response = Console.ReadLine();
            if (int.TryParse(response, out int responseInt))
            {
                if (responseInt >= 1 && responseInt <= 3999)
                {
                    return responseInt;
                }
            }

            return AskForInput(true);
        }
    }
}
