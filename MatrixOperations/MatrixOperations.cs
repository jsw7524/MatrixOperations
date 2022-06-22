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