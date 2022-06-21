using System;

namespace MyApp // Note: actual namespace depends on the project name.
{

    public class Matrix
    {
        public double[,] matrix;
        public int row;
        public int col;

        public static IMatrixOperations _matrixOperator;

        static Matrix()
        {
            _matrixOperator = MatrixHelper.GetMatrixOperator();
        }

        public double this[int r, int c]
        {
            get => matrix[r, c];
            set => matrix[r, c] = value;
        }

        public Matrix(double[,] data)
        {
            row = data.GetLength(0);
            col = data.GetLength(1);
            matrix = new double[row, col];
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    this[i, j] = data[i, j];
                }
            }
        }
        public static Matrix operator *(Matrix a, Matrix b)
        {
            return _matrixOperator.MultiplyMatrices(a, b);
        }

        public static Matrix operator *(double a, Matrix b)
        {
            return _matrixOperator.MultiplyMatrices(MatrixHelper.GetIdentityMatrix(b.row, a), b);
        }

        public static Matrix operator +(Matrix a, Matrix b)
        {
            return _matrixOperator.AddMatrices(a, b);
        }

        public Matrix(int r, int c)
        {
            row = r;
            col = c;
            matrix = new double[r, c];
        }
    }


    public static class MatrixHelper
    {
        static Random _random = new Random(7524);
        public static Matrix GetRandomMatrix(int r, int c)
        {
            Matrix m = new Matrix(r, c);
            for (int i = 0; i < r; i++)
            {
                for (int j = 0; j < c; j++)
                {
                    m[i, j] = _random.NextDouble();
                }
            }
            return m;
        }

        public static Matrix GetIdentityMatrix(int n, double defaultValue = 1.0)
        {
            Matrix m = new Matrix(n, n);
            for (int i = 0; i < n; i++)
            {
                m[i, i] = defaultValue;
            }
            return m;
        }

        public static IMatrixOperations GetMatrixOperator()
        {
            return MatrixOperations.Instance;
        }

    }

    public interface IMatrixOperations
    {
        Matrix AddMatrices(Matrix a, Matrix b);
        Matrix MultiplyMatrices(Matrix a, Matrix b);
    }


    public class MatrixOperations : IMatrixOperations
    {
        private MatrixOperations() { }
        private static IMatrixOperations _instance = null;
        private static readonly object _mutex = new object();
        public static IMatrixOperations Instance
        {
            get
            {
                lock (_mutex)
                {
                    if (_instance == null)
                    {
                        _instance = new MatrixOperations();
                    }
                }
                return _instance;
            }
        }

        public Matrix AddMatrices(Matrix a, Matrix b)
        {
            Matrix m = new Matrix(a.row, b.col);
            for (int i = 0; i < a.row; i++)
            {
                for (int j = 0; j < b.col; j++)
                {
                    m[i, j] = a[i, j] + b[i, j];
                }
            }
            return m;
        }

        public Matrix MultiplyMatrices(Matrix a, Matrix b)
        {
            Matrix m = new Matrix(a.row, b.col);
            for (int i = 0; i < a.row; i++)
            {
                for (int j = 0; j < b.col; j++)
                {
                    for (int k = 0; k < a.col; k++)
                    {
                        m[i, j] += a[i, k] * b[k, j];
                    }
                }
            }
            return m;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}