using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM_lab1
{
    class Calculator
    {
      
        double result = 0;
        private double Sum(double x1, double x2) // сложение
        {  
           return x1 + x2;                     
        }

        private double Sub(double x1, double x2) // вычитание
        {
            return  x1 - x2;
        }

        private double Mult(double x1, double x2) // умножение
        {
            return  x1 * x2;
        }

        private double Div(double x1, double x2) // деление
        {
            if (x2 == 0) { Console.WriteLine("Второе значение равно нулю"); }
            return  x1 / x2;
        }
        public double ResultFuction(double x1, double x2, int z)  // Результирующая функция
        {      
            switch (z)
            {
                case 1: result = Sum(x1, x2); break;
                case 2: result = Sub(x1, x2); break;
                case 3: result = Mult(x1, x2); break;
                case 4: result = Div(x1, x2); break;
            }
            return result;

        }
    }

    }

