using System;
using System.Collections.Generic;
using static System.Math;
//одномерная минимизация
//методы нахождения минимума функции
//Павлов Дмитрий 206 группа
//ln(1+x^2)-sin(x)
//Console.Write(""); Console.WriteLine();
namespace М.О
{
    class Program
    {
        const double left = 0;//левая граница  
        const double right = PI / 4;//правая граница
        const double eps = 1e-6;


        static void Main(string[] args)
        {
            Console.WriteLine("Функция ln(1+x^2)-sin(x)");
            Console.WriteLine("Нажмите цифру для одномерной минимизации:");
            Console.WriteLine("1.Методом пассивного поиска");
            Console.WriteLine("2.Методом дихотомии");
            Console.WriteLine("3.Методом золотого сечения");
            Console.WriteLine("4.Методом Фибоначчи");
            Console.WriteLine("5.Модифицированным методом Фибоначчи");
            Console.WriteLine("6.Методом Ньютона-Рафсона");
            Console.WriteLine("7.Методом секущих");
            Console.WriteLine("8.Методом касательных(тангенсов)");
            int key = Convert.ToInt16(Console.ReadLine());
            switch (key)
            {
                case 1:
                    PassiveSearch();
                    break;
                case 2:
                    Dichotomy();
                    break;
                case 3:
                    GoldenRatio();
                    break;
                case 4:
                    Console.WriteLine("Метод Фибоначчи");
                    Fibonacci(false);
                    break;
                case 5:
                    Console.WriteLine("Модифицированный методом Фибоначчи");
                    Fibonacci(true);
                    break;
                case 6:
                    NewtonRaphson();
                    break;
                case 7:
                    Secant();
                    break;
                case 8:
                    Tangents();
                    break;
                 
            }
        }


        static double Funct(double x)//возвращает значение функции в точке
        {
            return Log(1 + Pow(x, 2)) - Sin(x);
        }
        static double Derivative(double x)//производная
        {
            return (2 * x) / (1 + Pow(x, 2)) - Cos(x);
        }
        static double SecondDerivative(double x)//вторая производная
        {
            return Sin(x) - (2 * (Pow(x, 2) - 1)) / Pow(1 + Pow(x, 2), 2);
        }


        static void PassiveSearch()//метод пассивного поиска
        {
            Console.WriteLine("Метод пассивного поиска ");
            int i = 0;
            int k = Convert.ToInt32(right / (eps*10000) + 1);
            Console.Write("Число итераций: "); Console.WriteLine(k);
            double xi = X(i, k);
            double min = Funct(xi);
            double xmin = xi;
            Console.Write("Номер индекса i: "); Console.WriteLine(i);
            Console.Write("     Значение аргумента X(i) "); Console.WriteLine(xi);
            Console.Write("     Значение функции f(x(i)) "); Console.WriteLine(Funct(xi));
            i++;
            while (i <= k)
            {
                xi = X(i, k);
                double p = Funct(xi);
                if (min > p)
                {
                    xmin = xi;
                    min = p;
                }
                Console.Write("Номер индекса i: "); Console.WriteLine(i);
                Console.Write("     Значение аргумента X(i) "); Console.WriteLine(xi);
                Console.Write("     Значение функции f(x(i)) "); Console.WriteLine(Funct(xi));
                i++;
            }
            Console.Write("Минимальное значение достигается в x = "); Console.WriteLine(xmin);
            Console.Write("Значение функции в этой точке "); Console.WriteLine(min);
            Console.ReadKey();
        }

        static void Dichotomy()//метод дихотомии
        {
            Console.WriteLine("Метод дихотомии");
            double delta = eps / 5;
            int i = 0;
            double a = left;
            double b = right;
            double c, d;
            c = (a + b) / 2 - delta / 2;
            d = (a + b) / 2 + delta / 2;
            Console.Write("Номер индекса i: "); Console.WriteLine(i);
            Console.Write("     Левая граница "); Console.WriteLine(a);
            Console.Write("     Правая граница "); Console.WriteLine(b);
            Console.Write("     Точка c "); Console.WriteLine(c);
            Console.Write("     Значение функции в этой точке "); Console.WriteLine(Funct(c));
            Console.Write("     Точка d "); Console.WriteLine(d);
            Console.Write("     Значение функции в этой точке "); Console.WriteLine(Funct(d));
            if (Funct(c) <= Funct(d)) b = d;
            else a = c;
            while ((b - a) / 2 > eps)
            {
                i++;
                c = (a + b) / 2 - delta / 2;
                d = (a + b) / 2 + delta / 2;
                Console.Write("Номер индекса i: "); Console.WriteLine(i);
                Console.Write("     Левая граница "); Console.WriteLine(a);
                Console.Write("     Правая граница "); Console.WriteLine(b);
                Console.Write("     Точка c "); Console.WriteLine(c);
                Console.Write("     Значение функции в этой точке "); Console.WriteLine(Funct(c));
                Console.Write("     Точка d "); Console.WriteLine(d);
                Console.Write("     Значение функции в этой точке "); Console.WriteLine(Funct(d));
                if (Funct(c) <= Funct(d)) b = d;
                else a = c;
            }
            double min = Funct((a + b) / 2);

            Console.Write("Минимальное значение достигается в x = "); Console.WriteLine((a + b) / 2);
            Console.Write("Значение функции в этой точке "); Console.WriteLine(min);
            Console.ReadKey();
        }

        static void GoldenRatio()//золотое сечение
        {
            Console.WriteLine("Метод золотого сечения");
            int i = 0;
            double a = left;
            double b = right;
            double c = (3 - Sqrt(5)) / 2 * (b - a) + a;
            double d = (Sqrt(5) - 1) / 2 * (b - a) + a;
            Console.Write("Номер индекса i:"); Console.WriteLine(i);
            Console.Write("     Левая граница"); Console.WriteLine(a);
            Console.Write("     Правая граница"); Console.WriteLine(b);
            Console.Write("     Первая точка золотого сечения"); Console.WriteLine(c);
            Console.Write("     Значение функции в этой точке"); Console.WriteLine(Funct(c));
            Console.Write("     Вторая точка золотого сечения"); Console.WriteLine(d);
            Console.Write("     Значение функции в этой точке"); Console.WriteLine(Funct(d));
            while ((b - a) / 2 > eps)
            {
                i++;
                if (Funct(c) <= Funct(d))
                {
                    b = d;
                    d = c;
                    c = (3 - Sqrt(5)) / 2 * (b - a) + a;
                }
                else
                {
                    a = c;
                    c = d;
                    d = (Sqrt(5) - 1) / 2 * (b - a) + a;
                }
                Console.Write("Номер индекса i:"); Console.WriteLine(i);
                Console.Write("     Левая граница"); Console.WriteLine(a);
                Console.Write("     Правая граница"); Console.WriteLine(b);
                Console.Write("     Первая точка золотого сечения"); Console.WriteLine(c);
                Console.Write("     Значение функции в этой точке"); Console.WriteLine(Funct(c));
                Console.Write("     Вторая точка золотого сечения"); Console.WriteLine(d);
                Console.Write("     Значение функции в этой точке"); Console.WriteLine(Funct(d));
            }
            double min = Funct((a + b) / 2);

            Console.Write("Минимальное значение достигается в x = "); Console.WriteLine((a + b) / 2);
            Console.Write("Значение функции в этой точке"); Console.WriteLine(min);
            Console.ReadKey();
        }

        static void Fibonacci(bool Modif)//метод Фибoначчи
        {
            double a = left;
            double b = right;
            double c = 0, d;
            List<double> F = new List<double>();
            F.Add(1);
            if (Modif)
            {
                F.Add((1 + Sqrt(5)) / 2);
            }
            else F.Add(1);
            int i = 1;
            while ((b - a) / eps > F[i])
            {
                i++;
                F.Add(F[i - 1] + F[i - 2]);
            }
            int j=1;
            c = a + (b - a) * (Convert.ToDouble(F[i-2]) / Convert.ToDouble(F[i-2 + 2]));
            d = a + (b - a) * (Convert.ToDouble(F[i-2 + 1]) / Convert.ToDouble(F[i-2 + 2]));
            Console.Write("Число итераций: "); Console.WriteLine(i-1);
            Console.Write("Номер индекса i:"); Console.WriteLine(j);
            Console.Write("     Левая граница"); Console.WriteLine(a);
            Console.Write("     Правая граница"); Console.WriteLine(b);
            Console.Write("     Точка c "); Console.WriteLine(c);
            Console.Write("     Значение функции в этой точке "); Console.WriteLine(Funct(c));
            Console.Write("     Точка d "); Console.WriteLine(d);
            Console.Write("     Значение функции в этой точке "); Console.WriteLine(Funct(d));
            for (int n = i - 2; n > 0; n--)
            {
                j++;
                if (Funct(c) <= Funct(d))
                {
                    b = d;
                    d = c;
                    c = a + (b - a) * (Convert.ToDouble(F[n]) / Convert.ToDouble(F[n + 2]));
                }
                else
                {
                    a = c;
                    c = d;
                    d = a + (b - a) * (Convert.ToDouble(F[n + 1]) / Convert.ToDouble(F[n + 2]));
                }
                Console.Write("Номер индекса i:"); Console.WriteLine(j);
                Console.Write("     Левая граница"); Console.WriteLine(a);
                Console.Write("     Правая граница"); Console.WriteLine(b);
                Console.Write("     Точка c "); Console.WriteLine(c);
                Console.Write("     Значение функции в этой точке "); Console.WriteLine(Funct(c));
                Console.Write("     Точка d "); Console.WriteLine(d);
                Console.Write("     Значение функции в этой точке "); Console.WriteLine(Funct(d));
            }
            
            double min = Funct(c);

            Console.Write("Минимальное значение достигается в x = "); Console.WriteLine(c);
            Console.Write("Значение функции в этой точке"); Console.WriteLine(min);
            Console.ReadKey();
        }

        static void NewtonRaphson()
        {
            Console.WriteLine("Метод Ньютона-Рафсона");
            double a = left;
            double b = 0.556;
            double xi = a;
            int i = 0;
            Console.Write("Номер индекса i: "); Console.WriteLine(i);
            Console.Write("     Значение аргумента X(i) "); Console.WriteLine(xi);
            Console.Write("     Значение функции f(x(i)) "); Console.WriteLine(Funct(xi));
            Console.Write("     Значение производной F(X(i)) "); Console.WriteLine(Derivative(xi));
            Console.Write("     Значение второй производной F(X(i)) "); Console.WriteLine(SecondDerivative(xi));
            while (Abs(Derivative(xi)) > eps)
            {
                i++;
                xi = xi - Derivative(xi) / SecondDerivative(xi);
                Console.Write("Номер индекса i: "); Console.WriteLine(i);
                Console.Write("     Значение аргумента X(i) "); Console.WriteLine(xi);
                Console.Write("     Значение функции f(x(i)) "); Console.WriteLine(Funct(xi));
                Console.Write("     Значение производной F(X(i)) "); Console.WriteLine(Derivative(xi));
                Console.Write("     Значение второй производной F(X(i)) "); Console.WriteLine(SecondDerivative(xi));
                
            }
            Console.Write("Минимальное значение достигается в x = "); Console.WriteLine(xi);
            Console.Write("Значение функции в этой точке"); Console.WriteLine(Funct(xi));
            Console.ReadKey();
        }

        static void Secant()
        {
            Console.WriteLine("Метод секущих");
            double a = left;
            double b = right;
            double c = Intersection(a, b);
            int i = 0;
            Console.Write("Номер индекса i: "); Console.WriteLine(i);
            Console.Write("     Левая граница "); Console.WriteLine(a);
            Console.Write("     Правая граница "); Console.WriteLine(b);
            Console.Write("     Точка c "); Console.WriteLine(c);
            Console.Write("     Значение функции в этой точке "); Console.WriteLine(Funct(c));
            while (Abs(Derivative(b)) > eps)
            {
                i++;
                a = b;
                b = c;
                c = Intersection(a, b);
                Console.Write("Номер индекса i: "); Console.WriteLine(i);
                Console.Write("     Левая граница "); Console.WriteLine(a);
                Console.Write("     Правая граница "); Console.WriteLine(b);
                Console.Write("     Точка c "); Console.WriteLine(c);
                Console.Write("     Значение функции в этой точке "); Console.WriteLine(Funct(c));
            }
            Console.ReadKey();
        }

        static void Tangents()
        {
            Console.WriteLine("Метод касательных(тангенсов)");
            double a = left;
            double b = right;
            double c;//точка пересечения производных
            c = (a * Derivative(a) - b * Derivative(b) - Funct(a) + Funct(b))/(Derivative(a)-Derivative(b));
            int i = 0;
            Console.Write("Номер индекса i: "); Console.WriteLine(i);
            Console.Write("     Левая граница "); Console.WriteLine(a);
            Console.Write("     Правая граница "); Console.WriteLine(b);
            Console.Write("     Точка c "); Console.WriteLine(c);
            Console.Write("     Значение функции в этой точке "); Console.WriteLine(Funct(c));
            while ((Abs(b-a)>eps)&&(Abs(Derivative(c)) > eps)&&(Abs(Funct(a)-Funct(b))>eps))
            {
                i++;
                if (Derivative(c) > 0) b = c;
                else if (Derivative(c) < 0) a = c;
                else break;
                c = (a * Derivative(a) - b * Derivative(b) - Funct(a) + Funct(b)) / (Derivative(a) - Derivative(b));
                Console.Write("Номер индекса i: "); Console.WriteLine(i);
                Console.Write("     Левая граница "); Console.WriteLine(a);
                Console.Write("     Правая граница "); Console.WriteLine(b);
                Console.Write("     Точка c "); Console.WriteLine(c);
                Console.Write("     Значение функции в этой точке "); Console.WriteLine(Funct(c));
                Console.Write("     Значение производной F(X(i)) "); Console.WriteLine(Derivative(c));

            }
            Console.ReadKey();
        }

        static double X(int i, int k)//высчитывает х с индексом i для метода пассивного поиска
        {
            return i * ((right - left) / k);
        }
        static double Intersection(double x0, double x1)//пересечение для метода секущих
        {
            return x1 - Derivative(x1) * ((x1 - x0) / (Derivative(x1) - Derivative(x0)));
        }
    }
}