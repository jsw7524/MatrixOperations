namespace JswMatrix // Note: actual namespace depends on the project name.
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

            double[] tmp = new double[n];
            Parallel.For(0, n, c =>
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
                tmp[c] = Math.Pow(-1.0, c) * a[0, c] * DeterminantSingleThread(m);
            });
            return tmp.Sum();
        }


        public double DeterminantSingleThread(Matrix a)
        {
            if (a.col != a.row)
            {
                throw new Exception("Not a Square Matrix");
            }

            int n = a.col;

            if (n == 1)
            {
                return a[0, 0];
            }

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
                tmp += Math.Pow(-1.0, c) * a[0, c] * DeterminantSingleThread(m);
            }
            return tmp;
        }


        public Matrix CofactorMatrix(Matrix a)
        {
            int n = a.col;
            Matrix cofactorMatrix = new Matrix(n, n);
            for (int y = 0; y < n; y++)
            {
                for (int x = 0; x < n; x++)
                {
                    Matrix m = new Matrix(n - 1, n - 1);
                    for (int i = 0; i < y; i++)
                    {
                        for (int j = 0; j < x; j++)
                        {
                            m[i, j] = a[i, j];
                        }
                    }

                    for (int i = y + 1; i < n; i++)
                    {
                        for (int j = 0; j < x; j++)
                        {
                            m[i - 1, j] = a[i, j];
                        }
                    }

                    for (int i = 0; i < y; i++)
                    {
                        for (int j = x + 1; j < n; j++)
                        {
                            m[i, j - 1] = a[i, j];
                        }
                    }

                    for (int i = y + 1; i < n; i++)
                    {
                        for (int j = x + 1; j < n; j++)
                        {
                            m[i - 1, j - 1] = a[i, j];
                        }
                    }

                    cofactorMatrix[y, x] = Math.Pow(-1.0, y + x) * Determinant(m);
                }
            }
            return cofactorMatrix;
        }

        public Matrix InverseMatrix(Matrix a)
        {
            return (1.0 / a.Determinant()) * (a.CofactorMatrix()).T;
        }

        public Matrix GaussianElimination(Matrix a)
        {
            List<Matrix> rowOperations = new List<Matrix>();
            int n = a.row;
            for (int i = 0; i < n; i++)//col
            {
                Matrix tmp1 = MatrixHelper.GetIdentityMatrix(n);
                if (0.0 == a[i, i])
                {
                    int j = i + 1;
                    for (; j < n; j++)//swap row
                    {
                        if (0.0 != a[j, i])
                        {
                            a = MatrixHelper.RowSwap(a, i, j);
                            break;
                        }
                    }
                    if (j == n)
                    {
                        continue;
                    }
                }
                tmp1[i, i] = 1.0 / a[i, i];
                a = tmp1 * a;
                for (int j = i + 1; j < n; j++)//row
                {
                    Matrix tmp2 = MatrixHelper.GetIdentityMatrix(n);
                    tmp2[j, i] = -1.0 * a[j, i];
                    a = tmp2 * a;
                }
            }
            return a;
        }
    }
}