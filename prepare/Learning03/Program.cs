using System;

class Program
{
    static void Main(string[] args)
    {
        List<Fraction> fractions = new List<Fraction>();

        fractions.Add(new Fraction());
        fractions.Add(new Fraction(5));
        fractions.Add(new Fraction(3, 4));
        fractions.Add(new Fraction(1, 3));

        foreach (Fraction fraction in fractions){
            Console.WriteLine(fraction.GetFractionString());
            Console.WriteLine(fraction.GetDecimal().ToString());
        }
    }
}