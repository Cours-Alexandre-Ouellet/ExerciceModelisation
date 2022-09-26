using System;

namespace ExerciceRetroIngenerie
{
    public class Entier : Nombre
    {
        private readonly int nombre;

        public override TypeNombre TypeNombre => TypeNombre.ENTIER;

        public Entier(int nombre)
        {
            this.nombre = nombre;
        }

        public override object GetValeur()
        {
            return nombre;
        }

        public override Nombre Additionner(Nombre n)
        {
            if(n is null)
            {
                throw new ArgumentException("Le nombre est null.");
            }

#pragma warning disable CS8602
            try
            {
                return n.TypeNombre switch
                {
                    TypeNombre.ENTIER => new Entier((n as Entier).nombre + nombre),
                    TypeNombre.FRACTION => (n as Fraction).Additionner(new Fraction(nombre)),
                    _ => throw new ArgumentException("Le type de nombre ne peut pas être reconnu."),
                };
            }
            catch(NullReferenceException)
            {
                throw new ArgumentException("Impossible de convertir le nombre dans le type attendu.");
            }
#pragma warning restore CS8602
        }

        public override Nombre Multiplier(Nombre n)
        {
            if(n is null)
            {
                throw new ArgumentException("");
            }

#pragma warning disable CS8602
            try
            {
                return n.TypeNombre switch
                {
                    TypeNombre.ENTIER => new Entier((n as Entier).nombre * nombre),
                    TypeNombre.FRACTION => (n as Fraction).Multiplier(new Fraction(nombre)),
                    _ => throw new ArgumentException("Le type de nombre ne peut pas être reconnu."),
                };
            }
            catch(NullReferenceException)
            {
                throw new ArgumentException("Impossible de convertir le nombre dans le type attendu.");
            }
#pragma warning restore CS8602
        }

        public override string ToString()
        {
            return nombre.ToString();
        }
    }
}
