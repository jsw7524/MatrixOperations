namespace MyApp // Note: actual namespace depends on the project name.
{
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

        public Matrix Transpose(Matrix a)
        {
            Matrix m = new Matrix(a.col, a.row);
            for (int i = 0; i < a.row; i++)
            {
                for (int j = 0; j < a.col; j++)
                {
                    m[j, i] = a[i, j];
                }
            }
            return m;
        }

        public double Determinant(Matrix a)
        {
            if (a.col != a.row)
            {
                throw new Exception("Not a Square Matrix");
            }

            int n = a.col;
            if (n == 2)
            {
                return a[0, 0] * a[1, 1] - a[0, 1] * a[1, 0];
            }

            double tmp = 0.0;
            for (int c = 0; c < n; c++)
            {
                Matrix m = new Matrix(n - 1, n - 1);
                for (int i = 1; i < n; i++)
                {
                    for (int j = 0; j < c; j++)
                    {
                        m[i - 1, j] = a[i, j];
                    }
                }

                for (int i = 1; i < n; i++)
                {
                    for (int j = c + 1; j < n; j++)
                    {
                        m[i - 1, j - 1] = a[i, j];
                    }
                }
                tmp += Math.Pow(-1.0, c) * a[0, c] * Determinant(m);
            }

            return tmp;
        }

        //public double DotProduct(Matrix vectorA, Matrix vectorB)
        //{
        //    double tmp = 0.0;
        //    for (int i = 0; i < vectorA.row; i++)
        //    {
        //        tmp += vectorA[0, i] * vectorB[0, i];  
        //    }
        //    return tmp;
        //}
    }
}