namespace MyApp // Note: actual namespace depends on the project name.
{
    public class Vector : Matrix
    {
        public double this[int i]
        {
            get => matrix[i,0];
            set => matrix[i,0] = value;
        }

        public Vector(Matrix m) : base(m.row, 1)
        {
            for (int i = 0; i < m.row; i++)
            {
                matrix[i, 0] = m[i, 0];
            }
        }

        public Vector(double[] data) : base(data.Length, 1)
        {
            for (int i = 0; i < data.Length; i++)
            {
                matrix[i, 0] = data[i];
            }
        }

        public static Vector operator +(Vector a, Vector b)
        {
            return new Vector(matrixOperator.AddMatrices(a, b));
        }

        public static double operator *(Vector a, Vector b) //Dot Product
        {
            return (matrixOperator.MultiplyMatrices(a.T, b))[0,0];
        }

        public static Vector operator *(Matrix a, Vector b) //linear transform
        {
            return new Vector(matrixOperator.MultiplyMatrices(a, b));
        }

    }
}