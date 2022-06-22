using Newtonsoft.Json;

namespace MyApp // Note: actual namespace depends on the project name.
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
            return isMultiThread ? MatrixOperationsMT.Instance : MatrixOperations.Instance;
        }


        public static Matrix MatrixFromJson(string json)
        {
            return JsonConvert.DeserializeObject<Matrix>(json);
        }


    }
}