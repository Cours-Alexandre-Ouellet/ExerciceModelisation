namespace ExerciceRetroIngenerie
{
    public abstract class Nombre
    {
        public bool EstPositif { get; private set; }

        public abstract TypeNombre TypeNombre { get; }

        public abstract object GetValeur();

        public abstract Nombre Additionner(Nombre n);

        public Nombre Soustraire(Nombre n)
        {
            return Additionner(n.Multiplier(new Entier(-1)));
        }

        public abstract Nombre Multiplier(Nombre n);
    }
}
