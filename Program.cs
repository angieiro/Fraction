using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fraction_1
{
    public class Fraction
    {
        public int Numerator { get; set; }
        private int denominator;
        public int Denominator {
            get {
                return denominator;
            }
            set {
                if (value == 0)
                {
                    throw new ArithmeticException();
                }
                denominator = value;
            }
        }

        public decimal RationalNumber {
            get
            {
                return (decimal)Numerator / (decimal)Denominator;
            }
            //private set { }
        }

        public Fraction(int x, int y)
        {
            Numerator = x;
            Denominator = y;
        }

        public override string ToString()
        {
            return $"{Numerator}/{Denominator}";
        }

        public static Fraction operator *(Fraction x, Fraction y)
        {
            return new Fraction(x.Numerator * y.Numerator, x.Denominator * y.Denominator);
        }

        public override bool Equals(object obj)
        {
            var f = obj as Fraction;
            if (this.Numerator == f.Numerator && this.Denominator == f.Denominator)
            {
                return true;
            }
            return false;
        }


        public static Fraction Parse(String s)
        {
            String[] numbers = s.Split('/');

            int numer = Int32.Parse(numbers[0]);
            int denom = Int32.Parse(numbers[1]);

            return new Fraction(numer, denom);
        }

        public void Cancel()
        {
            int min = Math.Min(this.Numerator, this.Denominator);
            for (int i = min; i > 0; i--)
            {
                if ((Numerator % i == 0) && (Denominator % i == 0))
                {
                    Numerator = Numerator / i;
                    Denominator = Denominator / i;
                }
            }
            
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Fraction fract1 = new Fraction(1, 4);
            Console.WriteLine(fract1.ToString());

            Fraction fract2 = Fraction.Parse("1/5");

            Fraction fract3 = fract1 * fract2;
            Console.WriteLine(fract3.ToString());
            Console.WriteLine(fract3.RationalNumber);

            Fraction fract4 = new Fraction(9, 27);
            fract4.Cancel();
            Console.WriteLine(fract4.ToString());
            Console.WriteLine(fract4.Equals(new Fraction(1, 3)));

            Console.ReadKey();
        }
    }
}
