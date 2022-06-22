namespace MyApp // Note: actual namespace depends on the project name.
{
    public class MatrixOperationsMT : IMatrixOperations
    {
        private MatrixOperationsMT() { }
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
                        _instance = new MatrixOperationsMT();
                    }
                }
                return _instance;
            }
        }


        public Matrix AddMatrices(Matrix a, Matrix b)
        {
            Matrix m = new Matrix(a.row, b.col);
            Parallel.For(0, a.row, i =>
            {
                for (int j = 0; j < b.col; j++)
                {
                    m[i, j] = a[i, j] + b[i, j];
                }
            });
            return m;
        }

        public Matrix MultiplyMatrices(Matrix a, Matrix b)
        {
            // Parallel.For
            Matrix m = new Matrix(a.row, b.col);
            Parallel.For(0, a.row, i =>
            {
                for (int j = 0; j < b.col; j++)
                {
                    double temp = 0;
                    for (int k = 0; k < a.col; k++)
                    {
                        temp += a[i, k] * b[k, j];
                    }
                    m[i, j] = temp;
                }
            });
            return m;
        }

        public Matrix Transpose(Matrix a)
        {
            Matrix m = new Matrix(a.col, a.row);
            Parallel.For(0, a.row, i =>
            {
                for (int j = 0; j < a.col; j++)
                {
                    m[j, i] = a[i, j];
                }
            });
            return m;
        }

    }
}