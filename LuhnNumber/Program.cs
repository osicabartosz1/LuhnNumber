using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuhnNumber
{
    class Program
    {

        string number;
        int nextNumber;
        bool isLastNumberCorrect;

        static List<Program> history = new List<Program>();

        public Program(string number)
        {
            this.number = number;
            ComputeNextNumber(number);
            CheckIfIsCorrect(number);
        }

        private void CheckIfIsCorrect(string number)
        {
            int sum = 0;
            for (int i = 0; i < number.Length - 1; i++)
            {
                int sign = Int32.Parse(number.Substring(i, 1));

                sum += sign + sign * (i % 2);
            }
            isLastNumberCorrect = number.EndsWith((sum % 10).ToString());                
        }

        private void ComputeNextNumber(string number)
        {
            int sum = 0;
            for (int i = 0; i < number.Length; i++)
            {
                int sign = Int32.Parse(number.Substring(i, 1));
                sum += sign + sign * (i % 2);
            }
            nextNumber = sum % 10;
        }

        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Give me a number");
                string number = Console.ReadLine();
                if (!CheckNumber(number)) //initial test
                {
                    Console.WriteLine("WrongNumber");
                    continue;
                }

                Program p = new Program(number);//main computations
                p.print();
                history.Add(p);

                Console.WriteLine("Press 'Q' for Quit, 'H' print History");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "Q":
                        return;
                    case "H":
                        printHistory();
                        break;
                    default:
                        break;
                }
            }
        }

        private void print()
        {
            Console.WriteLine($"Next number is {nextNumber}");
            Console.WriteLine($"Has number {number} correct last digit: {isLastNumberCorrect}");
        }
        private static void printHistory()
        {
            foreach (var item in history)
            {
                item.print();
            }
        }

        static bool CheckNumber(string input) 
        {
            foreach (char sign in input) 
            {
                int test;
                if (!Int32.TryParse(sign.ToString(),out test)) return false;
            }
            return true;
        }
    }
}
