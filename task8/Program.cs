using System;

namespace task8
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.InputEncoding = System.Text.Encoding.Unicode;
            Console.OutputEncoding = System.Text.Encoding.Unicode;

            MyComplex A = new MyComplex(5, -9);
            MyComplex B = new MyComplex();
            _ = new MyComplex();
            _ = new MyComplex();
            _ = new MyComplex();
            _ = new MyComplex();

            Console.WriteLine(A);
            Console.WriteLine();

            B.InputNum(B);
            Console.WriteLine(B);
            Console.WriteLine();

            MyComplex C = A / B;
            Console.WriteLine($"C = A / B");
            Console.WriteLine(C);

            MyComplex D = C / 15;
            Console.WriteLine("D = C / 15");
            Console.WriteLine(D);

            MyComplex E = 13 / D;
            Console.WriteLine("E = 13 / D");
            Console.WriteLine(E);

            MyComplex F = -E;
            Console.WriteLine("F = -E");
            Console.WriteLine(F);
        }
    }

    class MyComplex
    {
        private double re;
        public double Re
        {
            get { return re; }
            set { re = value; }
        }

        private double im;
        public double Im
        {
            get { return im; }
            set { im = value; }
        }

        public MyComplex(double a = 0, double b = 0) { re = a; im = b; }

        private double InputReal()
        {
            bool flag = false;
            do
            {
                Console.Write("Re - ");
                string a = Console.ReadLine();
                flag = double.TryParse(a, out re);//преобразовывавем a в double и возвращаем в re,
                //и возвращаем в flag булевское значение произошло ли преобразование

                if (flag)
                {
                    break;//если преобразование сработало, выходим из цыкла, если нет, то данные не верны
                }
                else
                {
                    Console.WriteLine("Неправильні данні");
                    flag = true;
                }
            } while (flag);
            return re;
        }

        private double InputIm()
        {
            bool flag = false;
            do
            {
                Console.Write("Im - ");
                string a = Console.ReadLine();
                flag = double.TryParse(a, out im);

                if (flag)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Неправильні данні");
                    flag = true;
                }

            } while (flag);
            return im;
        }

        public void InputNum(MyComplex a)
        {
            a.InputReal();
            a.InputIm();
            Console.WriteLine();
        }


        public static MyComplex operator /(MyComplex a, MyComplex b)
        {
            return new MyComplex { re = a.re * b.im, im = -1 * a.im * b.re };
        }
        public static MyComplex operator /(MyComplex a, double b)
        {
            return new MyComplex { re = a.re / b, im = a.im / b };
        }
        public static MyComplex operator /(double b, MyComplex a)
        {
            return new MyComplex { re = b / a.re, im = b / a.im };
        }
        public static MyComplex operator -(MyComplex a)
        {
            return new MyComplex { Re = -1 * a.Re, Im = -1 * a.Im, };
        }
        public override string ToString()
        {
            if (Im < 0)
                return Re + "" + Im + "*i";
            else
                return Re + "+" + Im + "*i";
        }
    }
}
    