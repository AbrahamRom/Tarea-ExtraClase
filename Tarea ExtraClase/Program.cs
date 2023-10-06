using System;
namespace TareaEC
{
    class Program
    {
        static void Main(string[] args)
        {
            //   Console.WriteLine(EsSuperPrimo(2393));
            // Console.WriteLine(CadenasBalanceadas(3));
            // int[] x = { 1, 2, 3, };
            //  Console.WriteLine(SubsetSum(x, 4));
            //Console.WriteLine(KnightTour(6));
            int[,] figura = { { 1, -1 }, { 1, 2, }, { 0, 4 }, { -1, 2 }, { -1, -1 } };
            int[] punto = { 2, 3 };
            Console.WriteLine(PointInFigure(figura, punto));
        }

        //public static bool EsPrimo(int numero)
        //{
        //    if (numero <= 1)
        //    {
        //        return false;
        //    }

        //    for (int i = 2; i <= Math.Sqrt(numero); i++)
        //    {
        //        if (numero % i == 0)
        //        {
        //            return false;
        //        }
        //    }

        //    return true;
        //}

        //public static bool EsSuperPrimo(int numero)
        //{
        //    if (numero / 10 == 0) return EsPrimo(numero);
        //    else return EsPrimo(numero) && EsSuperPrimo(numero / 10);
        //}

        //public static int CadenasBalanceadas(int n) //n es el numero de pares de parentesis, o sea 2n es la cantidad de parentesis
        //{
        //    if (n <= 1) return 1;
        //    int CantCadenas = 0;
        //    for (int i = 0; i < n; i++)
        //    {
        //        CantCadenas += CadenasBalanceadas(i) * CadenasBalanceadas(n - 1 - i);
        //    }
        //    return CantCadenas;
        //}

        ///*
        //  public static int[] MergeSortRec(int[] x)
        //  {

        //  }
        //  public static int[] MergeSortRec(int[] x,int left,int right)
        //  {
        //      if (right-left==0)return x;
        //      int medio = (right + left) / 2;

        //    var IZ=  MergeSortRec(x,left,medio);
        //     var De= MergeSortRec(x,medio,right);

        //      int[] OrdenedArray = new int[IZ.Length + De.Length];
        //      for (int i = 0;i <= IZ.Length; i++)
        //      {
        //          for (int j = 0; j < De.Length; j++)
        //          {
        //              if (IZ[i] <= De[j])
        //          }
        //      }

        //  }*/

        //public static bool SubsetSum(int[] set, int k)
        //{

        //    return Suma_(set, k, 0, 0);

        //} // Suma de subconjunto de enteros
        //public static bool Suma_(int[] set, int k, int suma, int indice)
        //{
        //    if (suma == k) return true;
        //    if (indice >= set.Length) return false;
        //    if (Suma_(set, k, suma, indice + 1)) return true;
        //    suma += set[indice];
        //    if (Suma_(set, k, suma, indice + 1)) return true;
        //    return false;
        //}


        //public static bool KnightTour(int n)
        //{
        //    int[,] board = new int[n, n];
        //    int[] moveX = { 2, 1, -1, -2, -2, -1, 1, 2 };
        //    int[] moveY = { 1, 2, 2, 1, -1, -2, -2, -1 };
        //    board[0, 0] = 1;
        //    return KnightTourHelper(board, moveX, moveY, 1, 0, 0);
        //} // Recorrido del caballo

        ////static bool KnightTourHelper(int[,] board, int[] moveX, int[] moveY, int count, int x, int y)
        //{
        //    if (count == board.GetLength(0) * board.GetLength(1))
        //    {
        //        return true;
        //    }

        //    for (int i = 0; i < moveX.Length; i++)
        //    {
        //        int nextX = x + moveX[i];
        //        int nextY = y + moveY[i];

        //        if (nextX >= 0 && nextX < board.GetLength(0) && nextY >= 0 && nextY < board.GetLength(1) && board[nextX, nextY] == 0)
        //        {
        //            board[nextX, nextY] = count + 1;

        //            if (KnightTourHelper(board, moveX, moveY, count + 1, nextX, nextY))
        //            {
        //                return true;
        //            }

        //            board[nextX, nextY] = 0;
        //        }
        //    }

        //    return false;
        //}

        public static bool PointInFigure(int[,] figura, int[] punto)//Punto x,y dentro de un poligono convexo
        {
            bool PointInPerimeter = PointInPerimetro(figura, punto);
            if (PointInPerimeter) return false;
            for (int i = 2; i < figura.GetLength(0); i++)
            {
                int[,] triangulo = new int[3, 2];
                triangulo[0, 0] = figura[0, 0]; triangulo[0, 1] = figura[0, 1];
                triangulo[1, 0] = figura[i - 1, 0]; triangulo[1, 1] = figura[i - 2, 1];
                triangulo[2, 0] = figura[i, 0]; triangulo[2, 1] = figura[i, 1];
                if (PointInTriangle(triangulo, punto)) return true;
            }
            return false;
        }
        public static bool PointInTriangle(int[,] triangulo, int[] punto) // este metodo devuelve si un punto esta dentro de un triangulo, triangulo es de 3 x 2
        {
            //Dimension 0 son las X y dimension 1 las Y
            int[] PosA = { triangulo[0, 0], triangulo[0, 1], };
            int[] PosB = { triangulo[1, 0], triangulo[1, 1], };
            int[] PosC = { triangulo[2, 0], triangulo[2, 1], };
            // En caso de que Ey sea igual a 0(E paralelo al eje X), indefine el valor de n, entonces deben intercambiarse los Vectores
            if (PosC[1] - PosA[1] == 0)
            {
                PosB[0] = triangulo[2, 0]; PosB[1] = triangulo[2, 1];
                PosC[0] = triangulo[1, 0]; PosC[1] = triangulo[1, 1];
            }
            //Sea el vector D = AB y el vector E = AC
            // D = B - A // E = C - A
            int[] D = { PosB[0] - PosA[0], PosB[1] - PosA[1], };
            int[] E = { PosC[0] - PosA[0], PosC[1] - PosA[1], };
            // P = A + mD + nE // m y n Reales
            double m = (E[0] * (PosA[1] - punto[1]) + E[1] * (punto[0] - PosA[0])) / (double)(D[0] * E[1] - D[1] * E[0]);
            double n = (punto[1] - PosA[1] - m * D[1]) / (double)E[1];
            // Para que el punto este dentro del triangulo(o un lado) m y n deben ser ambos mayores-iguales que 0 y su suma menor-igual que 1
            bool PointInT = m >= 0 && n >= 0 && (m + n) <= 1;
            return PointInT;

        }
        public static bool PointInPerimetro(int[,] figura, int[] punto)
        {
            
            for(int i = 0; i < figura.GetLength(0); i++)
            {
                int[,] Puntos = new int[2,2];
                if (i != figura.GetLength(0) - 1)
                {
                    Puntos[0, 0] = figura[i, 0];Puntos[0, 1] = figura[i, 1]; Puntos[1, 0] = figura[i + 1, 0];Puntos[1,1]= figura[i + 1, 1]  ;
                }
                else { Puntos[0, 0] = figura[i, 0]; Puntos[0, 1] = figura[i, 1]; Puntos[1, 0] = figura[0, 0]; Puntos[1, 1] = figura[0, 1]; }
                if(PointInSide(Puntos,punto)) return true;
            }
            return false;
        }
        public static bool PointInSide(int[,] lado, int[] punto) //Para saber si un punto esta dentro del lado de la figura evaluando el punto con la funcion lineal
        {
            //Lo primero es que un punto dentro de un segmento debe estar entre las Xs de los puntos y las Ys de los mismos
            bool Cond1 = lado[0, 0] <= punto[0] && punto[0] <= lado[1, 0] && lado[0, 1] <= punto[1] && punto[1] <= lado[1, 1];
            bool Cond2 = lado[0, 0] >= punto[0] && punto[0] >= lado[1, 0] && lado[0, 1] >= punto[1] && punto[1] >= lado[1, 1];
            bool C = Cond1 || Cond2;
            if (C)
            {
                if ((lado[0, 0] - lado[1, 0]) == 0) return true; // paralelo al eje 0Y
                double m = (lado[1, 1] - lado[0, 1]) / (lado[1, 0] - lado[0, 0]);//la pendiente
                double n = lado[0,1]-m*lado[0,0]; // valor de n
                double Y = m * punto[0] + n;// ecuacion de la funcion lineal
                return (Y == punto[1]);
            }
            return false;
        }
    }
}