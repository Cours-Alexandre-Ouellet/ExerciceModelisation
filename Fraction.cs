using System;

namespace ExerciceRetroIngenerie
{
    public class Fraction : Nombre
    {
        private int numerateur;

        private int denominateur;

        public override TypeNombre TypeNombre => TypeNombre.FRACTION;

        public override object GetValeur()
        {
            return numerateur / (double) denominateur;
        }

        public Fraction(int numerateur, int denominateur = 1)
        {
            this.numerateur = numerateur;
            this.denominateur = denominateur;
        }

        public override Nombre Additionner(Nombre n)
        {
            Fraction fraction = ConvertirFraction(n);
            int ppcm = MathUtil.PPCM(denominateur, fraction.denominateur);

            int facteurA = ppcm / denominateur;
            int numerateurA = numerateur * facteurA;

            int facteurB = ppcm / fraction.denominateur;
            int numerateurB = fraction.numerateur * facteurB;

            Fraction resultat = new Fraction(numerateurA + numerateurB, ppcm);
            resultat.Simplifier();
            return resultat;
        }

        public override Nombre Multiplier(Nombre n)
        {
            Fraction fraction = ConvertirFraction(n);

            Fraction resultat = new Fraction(numerateur * fraction.numerateur, denominateur * fraction.denominateur);
            resultat.Simplifier();
            return resultat;
        }

        private Fraction ConvertirFraction(Nombre n)
        {
            if(n is null)
            {
                throw new ArgumentException("Le nombre est null.");
            }

            Fraction terme;

#pragma warning disable CS8600, CS8602
            try
            {
                terme = (n.TypeNombre == TypeNombre.ENTIER) ? new Fraction((int) (n as Entier).GetValeur()) : n as Fraction;
                if(terme is null)
                {
                    throw new NullReferenceException();     // On l'attrappe tout de suite, donc pas de message
                }

            }
            catch(NullReferenceException)
            {
                throw new ArgumentException("Impossible de convertir le nombre dans le type attendu.");
            }
#pragma warning restore CS8600, CS8602

            return terme;
        }

        private void Simplifier()
        {
            int pgcd = MathUtil.PGCD(numerateur, denominateur);
            if(pgcd != 1)
            {
                numerateur /= pgcd;
                denominateur /= pgcd;
            }
        }

        public override string ToString()
        {
            if(denominateur == 1)
            {
                return $"{numerateur}";
            }

            return $"{numerateur} / {denominateur}";
        }

    }
}
