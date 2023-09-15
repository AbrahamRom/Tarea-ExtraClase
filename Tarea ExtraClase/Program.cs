using System;
namespace TareaEC
{
    class Program
    {
        static void Main(string[] args)
        {
            //   Console.WriteLine(EsSuperPrimo(2393));
           // Console.WriteLine(CadenasBalanceadas(3));
        }

        public static bool EsPrimo(int numero)
        {
            if (numero <= 1)
            {
                return false;
            }

            for (int i = 2; i <= Math.Sqrt(numero); i++)
            {
                if (numero % i == 0)
                {
                    return false;
                }
            }

            return true;
        }

        public static bool EsSuperPrimo(int numero)
        {
            if (numero / 10 == 0) return EsPrimo(numero);
            else return EsPrimo(numero) && EsSuperPrimo(numero / 10);
        }

        public static int CadenasBalanceadas(int n) //n es el numero de pares de parentesis, o sea 2n es la cantidad de parentesis
        {
            if (n <= 1) return 1;
            int CantCadenas = 0;
            for (int i = 0; i < n; i++)
            {
                CantCadenas += CadenasBalanceadas(i)*CadenasBalanceadas(n-1-i);
            }
            return CantCadenas;
        }

    }
}