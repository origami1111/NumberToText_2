using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberToText_2
{
    class NumberToText
    {
        // сотни
        private static string[] tens =
        {
            "", "десять ", "двадцать ", "тридцать ", "сорок ", "пятьдесят ",
            "шестьдесят ", "семьдесят ", "восемьдесят ", "девяносто "
        };
        // десятки
        private static string[] hundreds =
        {
            "", "сто ", "двести ", "триста ", "четыреста ", "пятьсот ",
            "шестьсот ", "семьсот ", "восемьсот ", "девятьсот "
        };
        private static string[] frac20 =
        {
            "", "один ", "два ", "три ", "четыре ", "пять ", "шесть ",
            "семь ", "восемь ", "девять ", "десять ", "одиннадцать ", "двенадцать ",
            "тринадцать ", "четырнадцать ", "пятнадцать ", "шестнадцать ",
            "семнадцать ", "восемнадцать ", "девятнадцать "
        };

        // перевод в строку числа с учётом падежного окончания относящегося к числу существительного
        private static string Str(uint number, bool male, string one, string two, string five)
        {
            uint num = number % 1000;
            if (num == 0)
                return "";

            if (!male)
            {
                frac20[1] = "одна ";
                frac20[2] = "две ";
            }

            StringBuilder r = new StringBuilder(hundreds[num / 100]);

            if (num % 100 < 20)
                r.Append(frac20[num % 100]);
            else
            {
                r.Append(tens[num % 100 / 10]);
                r.Append(frac20[num % 10]);
            }

            r.Append(Case(num, one, two, five));

            if (r.Length != 0)
                r.Append(" ");

            return r.ToString();
        }

        // выбор правильного падежного окончания существительного
        // val - число, male - род существительного числа, one - сущ. для 1, two - сущ. для 2-4, five - сущ. для 5-10
        public static string Case(uint number, string one, string two, string five)
        {
            uint t = (number % 100 > 20) ? number % 10 : number % 20;

            switch (t)
            {
                case 1:
                    return one;
                case 2:
                case 3:
                case 4:
                    return two;
                default:
                    return five;
            }
        }

        // перевод целого числа в строку
        public static string Str(uint number)
        {
            StringBuilder r = new StringBuilder();

            if (number == 0)
                return r.Append("ноль ").ToString();

            if (number % 1000 != 0)
                r.Append(Str(number, true, "", "", ""));

            number /= 1000;

            r.Insert(0, Str(number, false, "тысяча", "тысячи", "тысяч"));
            number /= 1000;

            r.Insert(0, Str(number, true, "миллион", "миллиона", "миллионов"));
            number /= 1000;

            r.Insert(0, Str(number, true, "миллиард", "миллиарда", "миллиардов"));
            number /= 1000;

            return r.ToString();
        }
    }
}
