﻿namespace MyApp // Note: actual namespace depends on the project name.
{
    public interface IMatrixOperations
    {
        Matrix AddMatrices(Matrix a, Matrix b);
        Matrix MultiplyMatrices(Matrix a, Matrix b);
        Matrix Transpose(Matrix a);
        //double DotProduct(Matrix vectorA, Matrix vectorB);
    }
}