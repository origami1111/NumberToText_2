using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberToText_2
{
    class Program
    {
        static void Main(string[] args)
        {
            uint number = 0;

            Console.WriteLine($"Введите значение в диапазоне [0;{uint.MaxValue}]");
            Console.Write(" > ");

            try
            {
                number = Convert.ToUInt32(Console.ReadLine());

                Console.WriteLine("Output: ");
                Console.WriteLine($"{number} - {NumberToText.Str(number)}");
            }
            catch (OverflowException ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.WriteLine("Программа завершена");
            Console.ReadLine();
        }
    }
}
