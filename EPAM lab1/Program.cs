using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM_lab1
{
    class Program
    {
        
        static void Main(string[] args)
        {
            Calculator function = new Calculator();
            double x1, x2;
            int numfun, maxnumfun = 4, minnumfun = 0;
            
            try
            {
                Console.WriteLine("Выберите операцию (1 - сложение, 2 - вычитание, 3 - умножение, 4 - деление)");

                numfun = Convert.ToInt32(Console.ReadLine());
                if (numfun > maxnumfun || numfun < minnumfun)
                {
                    Console.WriteLine("Данной операции не существует");
                    Console.WriteLine("Выберите операцию (1 - сложение, 2 - вычитание, 3 - умножение, 4 - деление)");
                    numfun = Convert.ToInt32(Console.ReadLine());
                }

                Console.WriteLine("Первое число:");
                x1 = Convert.ToDouble(Console.ReadLine());

                Console.WriteLine("Второе число");
                x2 = Convert.ToDouble(Console.ReadLine());


                Console.WriteLine("Результат = " + function.ResultFuction(x1, x2, numfun));
            }
            catch (Exception e)
            { Console.WriteLine("Неверный тип введёных значений." + e.Message); }
           
       
           
        }

    }
}
