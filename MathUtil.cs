using System;

namespace ExerciceRetroIngenerie
{
    public static class MathUtil
    {
        public static int PPCM(int a, int b)
        {
            return Math.Abs(a * b) / PGCD(a, b);
        }

        public static int PGCD(int a, int b)
        {
            if(a < 0) { a *= -1; }
            if(b < 0) { b *= -1; }

            while(a != b)
            {
                if(a > b)
                {
                    a -= b;
                }
                else
                {
                    b -= a;
                }

            }

            return a;
        }
    }
}
