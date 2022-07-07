namespace JswMatrix // Note: actual namespace depends on the project name.
{
    public class Matrix
    {
        public double[,] matrix;
        public int row;
        public int col;

        public static IMatrixOperations matrixOperator;

        static Matrix()
        {
            matrixOperator = MatrixHelper.GetMatrixOperator();
        }

        public Matrix()
        {

        }

        public Matrix(List<Vector> vectors)
        {
            row = vectors.FirstOrDefault().row;
            col = vectors.Count();
            matrix = new double[row, col];
            int i = 0;
            foreach (Vector v in vectors)
            {
                for (int j = 0; j < v.row; j++)
                {
                    this[j, i] = v[j, 0];
                }
                i += 1;
            }
        }

        public double this[int r, int c]
        {
            get => matrix[r, c];
            set => matrix[r, c] = value;
        }

        public Matrix T
        {
            get => matrixOperator.Transpose(this);
        }

        int _rank = -1;
        public int Rank
        {
            get
            {
                if (_rank == -1)
                {
                    _rank = matrixOperator.Rank(this);
                }
                return _rank;
            }
        }

        bool? _isSingular = null;
        public bool? isSingular
        {
            get => _isSingular == null ? 0.0 == matrixOperator.Determinant(this) : _isSingular;
        }

        /// ///////////////////////

        public Vector GetColumn(int columnNumber)
        {
            return new Vector(Enumerable.Range(0, this.matrix.GetLength(0))
                    .Select(y => this[y, columnNumber])
                    .ToArray());
        }

        public IEnumerable<Vector> GetColumns()
        {
            return Enumerable.Range(0, this.matrix.GetLength(1)).Select(c => this.GetColumn(c));
        }

        public Vector GetRow( int rowNumber)
        {
            return new Vector(Enumerable.Range(0, this.matrix.GetLength(1))
                    .Select(x => this.matrix[rowNumber, x])
                    .ToArray());
        }

        public IEnumerable<Vector> GetRows()
        {
            return Enumerable.Range(0, this.matrix.GetLength(0)).Select(r => this.GetRow(r));
        }

        /// //////////////////////////////////////////////

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

        public double Determinant()
        {
            return matrixOperator.Determinant(this);
        }

        public Matrix GaussianJordan()
        {
            return matrixOperator.GaussianJordan(this);
        }


        public Matrix GaussianElimination()
        {
            return matrixOperator.GaussianElimination(this);
        }
        public Matrix CofactorMatrix()
        {
            return matrixOperator.CofactorMatrix(this);
        }
        public Matrix InverseMatrix()
        {
            return matrixOperator.InverseMatrix(this);
        }



        public static Matrix operator *(Matrix a, Matrix b)
        {
            return matrixOperator.MultiplyMatrices(a, b);
        }

        public static Matrix operator *(double a, Matrix b)
        {
            return matrixOperator.MultiplyMatrices(MatrixHelper.GetIdentityMatrix(b.row, a), b);
        }

        public static Matrix operator +(Matrix a, Matrix b)
        {
            return matrixOperator.AddMatrices(a, b);
        }
        public Matrix(int r, int c)
        {
            row = r;
            col = c;
            matrix = new double[r, c];
        }
    }
}