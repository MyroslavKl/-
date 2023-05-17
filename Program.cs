using _5._1;
using System;

class Program
{
    public static void Main(string[] args)
    {
        Matrix m = new Matrix(3);
        double[,] matrix = m.CreateMatrix();
        m.Spa(matrix);
    }

}
