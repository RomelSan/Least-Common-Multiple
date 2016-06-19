using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LCM
{
    class Program
    {
        static void Main(string[] args)
        {
            int op1 = 0;

            Console.WriteLine("How many numbers (Minimum 2): ");
            string user_input = Console.ReadLine();
            try
            {
                op1 = Convert.ToInt32(user_input);
            }
            catch
            {
                Console.WriteLine("Invalid number!");
                Console.ReadKey();
                Environment.Exit(0);
            }
            if (op1 < 2)
            {
                Console.WriteLine("Please enter an integer equal or greater than 2");
                Console.ReadKey();
                Environment.Exit(0);
            }

            double[] array = new double[op1];
            for (int i = 0; i < op1; i++)
            {
                try
                {
                    Console.WriteLine("Insert data [" + i + "]:  ");
                    array[i] = Convert.ToDouble(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("Invalid number!");
                    Console.ReadKey();
                    Environment.Exit(0);
                }
            }

            int aux0 = op1 - 1;
            double[] num = new double[aux0];
            double[] den = new double[aux0];
            num[0] = numerator(1, 1, array[0], array[1]);
            den[0] = denominator(array[0], array[1]);

            int pom = op1 - 2;

            for (int a = 1; a < aux0; a++)
            {

                int aux = a + 1;
                int aux00 = a - 1;
                num[a] = numerator(num[aux00], den[aux00], 1, array[aux]);
                den[a] = denominator(den[aux00], array[aux]);
            }
            //Detail
            /*
            for (int i = 0; i < aux0; i++)
            {
                Console.WriteLine("Numerator [{0}]: " + num[i]+"      Denominator[{0}]: "+den[i], i,i);
            }

            Console.ReadLine();

            Console.WriteLine("Numerator: {0}", num[op1-2]);
            Console.WriteLine("Denominator: {0}", den[op1-2]);
            Console.WriteLine("Least Divider: {0}", mcd(num[op1-2], den[op1-2]));
            */
            // End Detail
            Console.WriteLine("Least Common Multiple: {0}", (den[op1 - 2] / mcd(num[op1 - 2], den[op1 - 2])));
            Console.ReadLine();
        }

        static double mcd(double numerator, double denominator)
        {
            double mcd = 0;
            double a = Math.Max(numerator, denominator);
            double b = Math.Min(numerator, denominator);
            do
            {
                mcd = b;
                b = a % b;
                a = mcd;
            } while (b != 0);
            return mcd;
        }

        static double numerator(double a, double b, double c, double d)
        {
            double numerator = 0;
            numerator = a * d + b * c;
            return numerator;
        }
        static double denominator(double b, double d)
        {
            double denominator = 0;
            denominator = b * d;
            return denominator;
        }
    }
}
