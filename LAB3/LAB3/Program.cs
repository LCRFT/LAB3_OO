using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB3
{
    class Program
    {
        // public static double[,,] Matrix_3d(int n)
        // {
        public static int od_p = 0;
        //}
        public static double[,] Matrix_A(int n)
        {
            int chyslo = n;
            double[,] A = new double[n, n];
                for(int i=0;i<n;++i)
                {
                for(int j = 0; j < n; ++j)
                    {
                    if (i == j)
                    {
                        A[i, j] = chyslo;
                        --chyslo;
                    }
                    else A[i, j] = 0;
                    }
                }
            return A;
        }
        public static double[,] Matrix_B(int n)
        {
            Random rand = new Random();
            int chyslo = 0;
            double[,] B = new double[n, n];
            for (int i = 0; i < n; ++i)
            {
                for (int j = 0; j < n; ++j)
                {

                    if (j >= chyslo)
                    {
                        B[i, j] = rand.Next(10 - 1);
                    }
                    else B[i, j] = 0;
                }
                ++chyslo;
            }
            return B;
        }
        public static void Show(double[,] arr, int n, string name)
        {
            Console.WriteLine(name);

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write(arr[i, j] + "\t\t");
                }
                Console.WriteLine();
            }

            Console.WriteLine();
        }
        public static double [,,] OneTimeAssignment(double [,] A, double [,] B,int n)
        {
            double[,,] matrix_3d1 = new double[n, n, n + 1];
            
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    matrix_3d1[i, j, 0] = 0;

                    for (int k = 0; k < n; k++)
                    {
                            matrix_3d1[i, j, k + 1] = matrix_3d1[i, j, k] + A[i, k] * B[k, j];
                            od_p+=2;
                    }
                }
            }
            Console.Write("Алгоритм з одноразовим присвоєнням .\nКiлькiсть  присвоєнь:" + od_p);
            od_p = 0;
            Console.WriteLine();
            return matrix_3d1;
        }
        public static double[,,] LocallyRecursiveAlgorithm1(double [,] A, double [,] B, double[,,] matrix_3d2, int i, int j, int k,int n)
        {
            if (i < n & j < n & k < n)
            {

                if (A[i, k] != 0 & B[k, j] != 0)
                {
                    matrix_3d2[i, j, n] += A[i, k] * B[k, j];
                    od_p+=2;
                }

                k = (k == n - 1) ? 0 : k + 1;
                j = (k == 0 & j == n - 1) ? 0 : ((k == 0) ? j + 1 : j);
                i = (k == 0 & j == 0) ? i + 1 : i;
                LocallyRecursiveAlgorithm1(A, B, matrix_3d2 ,i, j, k,n);

           }      
            return matrix_3d2;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Введiть n:");
            int n = int.Parse(Console.ReadLine().ToString());
            double[,] A = Matrix_A(n);
            double[,] B = Matrix_B(n);
            Show(A, n, "A");
            Show(B, n, "B");
            double[,,] C = OneTimeAssignment(A, B, n);
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write(C[i, j, n] + "\t\t");
                }
                Console.WriteLine();
            }
            double[,,] matrix_3d2 = new double[n, n, n+1];
            double[,,] D = LocallyRecursiveAlgorithm1(A, B, matrix_3d2, 0, 0, 0, n);
            Console.WriteLine();
            Console.Write("Локально-рекурсивний алгоритм.\nКiлькiсть  присвоєнь:" + od_p);
            Console.WriteLine();
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write(D[i, j, n] + "\t\t");
                }
                Console.WriteLine();
            }
            Console.ReadKey();
        }
    }
}
