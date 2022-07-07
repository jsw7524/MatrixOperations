namespace JswMatrix // Note: actual namespace depends on the project name.
{
    public interface IMatrixOperations
    {
        Matrix AddMatrices(Matrix a, Matrix b);
        Matrix MultiplyMatrices(Matrix a, Matrix b);
        Matrix Transpose(Matrix a); 
        double Determinant(Matrix a);
        Matrix CofactorMatrix(Matrix a);
        Matrix InverseMatrix(Matrix a);

        Matrix GaussianElimination(Matrix a);

        Matrix GaussianJordan(Matrix a);
        int Rank(Matrix a);
    }

}