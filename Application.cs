using System;

namespace ExerciceRetroIngenerie
{
    public class Application
    {
        public static void Main(string[] args)
        {
            Entier a = new (5);
            Entier b = new (-2);
            Fraction c = new (1, 2);
            Fraction d = new (-5, 4);

            // Quelques scénarios d'exécution
            Console.WriteLine($"{ a.Additionner(b)}, {a.Additionner(c)}, {d.Additionner(c)}, {b.Additionner(c)}");
            Console.WriteLine($"{ a.Soustraire(b)}, {a.Soustraire(c)}, {d.Soustraire(c)}, {b.Soustraire(c)}");
            Console.WriteLine($"{ a.Multiplier(b)}, {a.Multiplier(c)}, {d.Multiplier(c)}, {b.Multiplier(c)}");
        }
    }
}
