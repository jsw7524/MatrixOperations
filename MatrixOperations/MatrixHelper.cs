using Newtonsoft.Json;

namespace JswMatrix // Note: actual namespace depends on the project name.
{
    public static class MatrixHelper
    {
        static Random _random = new Random(7524);
        static bool isMultiThread = true;
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

        public static Matrix MultiplyAllMatrices(IList<Matrix> matrices)
        {
            int n = matrices[0].row;
            Matrix result=MatrixHelper.GetIdentityMatrix(n);
            foreach (Matrix m in matrices)
            {
                result = result * m;
            }
            return result;
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

        public static Matrix RowSwap(Matrix a, int r1, int r2)
        {
            int rowSize = a.row;
            Matrix tmp = GetIdentityMatrix(rowSize);
            tmp[r1, r1] = 0;
            tmp[r2, r2] = 0;
            tmp[r1, r2] = 1;
            tmp[r2, r1] = 1;
            return tmp * a;
        }

        public static Matrix MoveToLastRow(Matrix a, int targetRow)
        {
            int rowSize = a.row;
            Matrix tmp = GetIdentityMatrix(rowSize, 0);
            for (int i = 0; i < targetRow; i++)
            {
                tmp[i, i] = 1.0;
            }
            for (int i = targetRow; i < rowSize-1; i++)
            {
                tmp[i, i+1] = 1.0;
            }
            tmp[rowSize - 1, targetRow] = 1.0;
            return tmp;
        }

        public static IMatrixOperations GetMatrixOperator()
        {
            return isMultiThread ? MatrixOperationsMT.Instance : MatrixOperations.Instance;
        }


        public static Matrix MatrixFromJson(string json)
        {
            return JsonConvert.DeserializeObject<Matrix>(json);
        }

        public static string MatrixToJson(Matrix a)
        {
            return JsonConvert.SerializeObject(a);
        }


    }
}