using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5._1
{
    public class Matrix
    {
        private double[,] matrix;

        public Matrix(int size)
        {
            this.matrix = new double[size, size];
        }

        public int GetLength
        {
            get { return this.matrix.GetLength(0); }
        }

        public double[,] CreateMatrix()
        {
            Console.WriteLine("Enter the elements of the matrix:");

            for (int i = 0; i < GetLength; i++)
            {
                for (int j = 0; j < GetLength; j++)
                {
                    Console.Write("matrix[{0},{1}] = ", i, j);
                    matrix[i, j] = double.Parse(Console.ReadLine());
                }
            }
            return matrix;
        }

        public void Spa(double[,]matrix) {
            double[] eigenVector = new double[GetLength];
            double eigenValue = 0;
            double eigenValuePrev = 1;
            double eps = 0.0001;
            for (int i = 0; i < GetLength; i++)
            {
                eigenVector[i] = 1;
            }
            while (Math.Abs(eigenValue - eigenValuePrev) > eps)
            {
                eigenValuePrev = eigenValue;
                double[] newEigenVector = new double[GetLength];
                for (int i = 0; i < GetLength; i++)
                {
                    for (int j = 0; j < GetLength; j++)
                    {
                        newEigenVector[i] += matrix[i, j] * eigenVector[j];
                    }
                }
                double norm = 0;
                for (int i = 0; i < GetLength; i++)
                {
                    norm += newEigenVector[i] * newEigenVector[i];
                }
                norm = Math.Sqrt(norm);
                for (int i = 0; i < GetLength; i++)
                {
                    eigenVector[i] = newEigenVector[i] / norm;
                }

                double[] tempVector = new double[GetLength];
                for (int i = 0; i < GetLength; i++)
                {
                    for (int j = 0; j < GetLength; j++)
                    {
                        tempVector[i] += matrix[i, j] * eigenVector[j];
                    }
                }
                eigenValue = tempVector[0] / eigenVector[0];
            }
            Console.WriteLine($"Найбільше за модулем власне число: {eigenValue}");
            Console.WriteLine("Власний вектор:");
            for (int i = 0; i < GetLength; i++)
            {
                Console.WriteLine(eigenVector[i]);
            }
        }
    }
}
