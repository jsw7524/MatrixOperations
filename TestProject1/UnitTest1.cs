using Microsoft.VisualStudio.TestTools.UnitTesting;
using JswMatrix;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace TestProject1
{
    [TestClass]
    public class UnitTest1
    {


        [TestMethod]
        public void TestMethod1()
        {
            Matrix identityMatrix1 = MatrixHelper.GetIdentityMatrix(3);
            Matrix identityMatrix2 = MatrixHelper.GetIdentityMatrix(3);
            Matrix result = identityMatrix1 * identityMatrix2;
            Assert.AreEqual(1.0, result[0, 0]);
            Assert.AreEqual(0.0, result[0, 1]);
            Assert.AreEqual(0.0, result[0, 2]);
            Assert.AreEqual(0.0, result[1, 0]);
            Assert.AreEqual(1.0, result[1, 1]);
            Assert.AreEqual(0.0, result[1, 2]);
            Assert.AreEqual(0.0, result[2, 0]);
            Assert.AreEqual(0.0, result[2, 1]);
            Assert.AreEqual(1.0, result[2, 2]);
            Assert.AreEqual(3, result.row);
            Assert.AreEqual(3, result.col);
        }

        [TestMethod]
        public void TestMethod2()
        {
            Matrix identityMatrix = MatrixHelper.GetIdentityMatrix(2);
            Matrix randomMatrix = MatrixHelper.GetRandomMatrix(2, 2);
            Matrix result = identityMatrix * randomMatrix;

            Assert.AreEqual(randomMatrix[0, 0], result[0, 0]);
            Assert.AreEqual(randomMatrix[0, 1], result[0, 1]);
            Assert.AreEqual(randomMatrix[1, 0], result[1, 0]);
            Assert.AreEqual(randomMatrix[1, 1], result[1, 1]);
        }

        [TestMethod]
        public void TestMethod3()
        {
            Matrix matrixA = new Matrix(new double[2, 2] { { 0, 1 }, { 0, 0 } });
            Matrix matrixB = new Matrix(new double[2, 2] { { 0.0, 0.0 }, { 1.0, 0.0 } });
            Matrix result1 = matrixA * matrixB;
            Assert.AreEqual(1.0, result1[0, 0]);
            Assert.AreEqual(0.0, result1[0, 1]);
            Assert.AreEqual(0.0, result1[1, 0]);
            Assert.AreEqual(0.0, result1[1, 1]);

            Matrix result2 = matrixB * matrixA;
            Assert.AreEqual(0.0, result2[0, 0]);
            Assert.AreEqual(0.0, result2[0, 1]);
            Assert.AreEqual(0.0, result2[1, 0]);
            Assert.AreEqual(1.0, result2[1, 1]);
        }

        [TestMethod]
        public void TestMethod4()
        {
            Matrix matrixA = new Matrix(new double[2, 2] { { 0, 1 }, { 0, 0 } });
            Matrix matrixB = new Matrix(new double[2, 2] { { 0.0, 0.0 }, { 1.0, 0.0 } });
            Matrix result = matrixA + matrixB;
            Assert.AreEqual(0.0, result[0, 0]);
            Assert.AreEqual(1.0, result[0, 1]);
            Assert.AreEqual(1.0, result[1, 0]);
            Assert.AreEqual(0.0, result[1, 1]);
        }

        [TestMethod]
        public void TestMethod5()
        {
            double scalerA = 3.0;
            Matrix matrixB = new Matrix(new double[2, 2] { { 1.0, 5.0 }, { 3.0, 0.0 } });
            Matrix result = scalerA * matrixB;
            Assert.AreEqual(3.0, result[0, 0]);
            Assert.AreEqual(15.0, result[0, 1]);
            Assert.AreEqual(9.0, result[1, 0]);
            Assert.AreEqual(0.0, result[1, 1]);
        }

        [TestMethod]
        public void TestMethod6()
        {
            Matrix identityMatrix1 = MatrixHelper.GetIdentityMatrix(2);
            Matrix result = identityMatrix1 + 2.0 * identityMatrix1 + 3.0 * identityMatrix1;
            Assert.AreEqual(6.0, result[0, 0]);
            Assert.AreEqual(0.0, result[0, 1]);
            Assert.AreEqual(0.0, result[1, 0]);
            Assert.AreEqual(6.0, result[1, 1]);
        }

        [TestMethod]
        public void TestMethod7()
        {
            Matrix matrixA = new Matrix(new double[2, 3] { { 1, 2, 3 }, { 4, 5, 6 } });
            Matrix result = matrixA.T;
            Assert.AreEqual(1.0, result[0, 0]);
            Assert.AreEqual(4.0, result[0, 1]);
            Assert.AreEqual(2.0, result[1, 0]);
            Assert.AreEqual(5.0, result[1, 1]);
            Assert.AreEqual(3.0, result[2, 0]);
            Assert.AreEqual(6.0, result[2, 1]);
        }

        [TestMethod]
        public void TestMethod8()
        {
            Vector a = new Vector(new double[3] { 1, 2, 3 });
            Vector b = new Vector(new double[3] { 4, 5, 6 });
            Vector result = a + b;
            Assert.AreEqual(5.0, result[0]);
            Assert.AreEqual(7.0, result[1]);
            Assert.AreEqual(9.0, result[2]);
        }


        [TestMethod]
        public void TestMethod9()
        {
            Vector a = new Vector(new double[3] { 1, 2, 3 });
            Vector b = new Vector(new double[3] { 4, 5, 6 });
            double result = a * b;
            Assert.AreEqual(32.0, result);
        }

        [TestMethod]
        public void TestMethod10()
        {
            Matrix matrixA = new Matrix(new double[,] { { 1, 0, -1 }, { 3, 1, 2 } });
            Vector b = new Vector(new double[3] { 1, 2, 3 });
            Vector result = matrixA * b;
            Assert.AreEqual(-2.0, result[0]);
            Assert.AreEqual(11.0, result[1]);
        }


        [TestMethod]
        public void TestMethod11()
        {
            Vector a = new Vector(new double[3] { 1, 2, 3 });
            Vector b = new Vector(new double[3] { 4, 5, 6 });
            Matrix result = new Matrix(new List<Vector>() { a, b });
            Assert.AreEqual(2, result.col);
            Assert.AreEqual(3, result.row);
            Assert.AreEqual(1.0, result[0, 0]);
            Assert.AreEqual(4.0, result[0, 1]);
            Assert.AreEqual(6.0, result[2, 1]);
        }


        [TestMethod]
        public void TestMethod12()
        {
            Vector a = new Vector(new double[3] { 1, 2, 3 });
            Vector b = new Vector(new double[3] { 4, 5, 6 });
            Vector result = 2.0 * a + 3.0 * b;
            Assert.AreEqual(14.0, result[0]);
            Assert.AreEqual(19.0, result[1]);
            Assert.AreEqual(24.0, result[2]);
        }



        [TestMethod]
        public void TestMethod13()
        {
            Vector a = new Vector(new double[3] { 3, -3, 1 });
            Vector b = new Vector(new double[3] { 4, 9, 2 });
            Vector result = a ^ b;
            Assert.AreEqual(-15.0, result[0]);
            Assert.AreEqual(-2.0, result[1]);
            Assert.AreEqual(39.0, result[2]);
        }

        [TestMethod]
        public void TestMethod14()
        {
            Matrix identityMatrix = MatrixHelper.GetIdentityMatrix(3);
            double result = identityMatrix.Determinant();
            Assert.AreEqual(1.0, result);
        }

        [TestMethod]
        public void TestMethod15()
        {
            Matrix m = new Matrix(new double[,] { { 3, 1, 1 }, { 4, -2, 5 }, { 2, 8, 7 } });
            double result = m.Determinant();
            Assert.AreEqual(-144.0, result);
        }

        [TestMethod]
        public void TestMethod16()
        {
            Matrix m = new Matrix(new double[,] { { 4, 3, 2, 2 }, { 0, 1, -3, 3 }, { 0, -1, 3, 3 }, { 0, 3, 1, 1 } });
            double result = m.Determinant();
            Assert.AreEqual(-240.0, result);
        }

        [TestMethod]
        public void TestMethod17()
        {
            Matrix m = new Matrix(new double[,] { { 1, 2, 3 }, { 0, 4, 5 }, { 1, 0, 6 } });
            Matrix result = m.CofactorMatrix();
            Assert.AreEqual(24.0, result[0, 0]);
            Assert.AreEqual(3.0, result[1, 1]);
            Assert.AreEqual(-5.0, result[2, 1]);
        }

        [TestMethod]
        public void TestMethod18()
        {
            Matrix m = new Matrix(new double[,] { { 1, 9, 3 }, { 2, 5, 4 }, { 3, 7, 8 } });
            Matrix result = m.CofactorMatrix();
            Assert.AreEqual(12.0, result[0, 0]);
            Assert.AreEqual(-1.0, result[1, 1]);
            Assert.AreEqual(2.0, result[2, 1]);
        }

        [TestMethod]
        public void TestMethod19()
        {
            Matrix m = new Matrix(new double[,] { { 1, 2, 3 }, { 0, 1, 5 }, { 5, 6, 0 } });
            Matrix result = m.InverseMatrix();
            Assert.AreEqual(-6.0, result[0, 0]);
            Assert.AreEqual(-3.0, result[1, 1]);
            Assert.AreEqual(-1, result[2, 0]);
            Assert.AreEqual(5.0, result[1, 0]);
        }

        [TestMethod]
        public void TestMethod20()
        {
            Matrix m = new Matrix(new double[,] { { 1, 2, 3 }, { 0, 1, 5 }, { 5, 6, 0 } });
            Matrix inverseMatrix = m.InverseMatrix();
            Matrix result = inverseMatrix * m;

            Assert.AreEqual(1.0, Math.Round(result[0, 0], 14));
            Assert.AreEqual(1.0, Math.Round(result[1, 1], 14));
            Assert.AreEqual(1.0, Math.Round(result[2, 2], 14));
            Assert.AreEqual(0.0, Math.Round(result[2, 0], 14));
            Assert.AreEqual(0.0, Math.Round(result[1, 0], 14));
            Assert.AreEqual(0.0, Math.Round(result[2, 1], 14));
            Assert.AreEqual(0.0, Math.Round(result[2, 0], 14));
            Assert.AreEqual(0.0, Math.Round(result[1, 2], 14));
            Assert.AreEqual(0.0, Math.Round(result[0, 1], 14));
        }

        [TestMethod]
        public void TestMethod21()
        {

            Matrix matrixA = new Matrix(new double[,] { { 1, 2, 2, 1 }, { 1, 2, 4, 2 }, { 2, 7, 5, 2 }, { -1, 4, -6, 3 } });
            double result = matrixA.Determinant();
            Assert.AreEqual(-42.0, result);
        }

        [TestMethod]
        public void TestMethod22()
        {
            Matrix matrixA = new Matrix(new double[,] { { 1, 0, 0, 0, 0 }, { 0, 1, 0, 0, 0 }, { 0, 0, -1, -1, 0 }, { 0, 0, 0, 1, 0 }, { 0, 0, 0, 0, 1 } });
            Matrix result = matrixA.InverseMatrix();
            Assert.AreEqual(1.0, result[0, 0]);
            Assert.AreEqual(1.0, result[1, 1]);
            Assert.AreEqual(-1.0, result[2, 2]);
            Assert.AreEqual(1.0, result[3, 3]);
            Assert.AreEqual(1.0, result[4, 4]);
            Assert.AreEqual(-1.0, result[2, 3]);
        }

        [TestMethod]
        public void TestMethod23()
        {
            Matrix matrixA = MatrixHelper.GetRandomMatrix(12, 12);
            Matrix inverseMatrix = matrixA.InverseMatrix();
            Matrix result = matrixA * inverseMatrix;
            Assert.AreEqual(1.0, Math.Round(result[0, 0], 12));
            Assert.AreEqual(1.0, Math.Round(result[1, 1], 12));
            Assert.AreEqual(1.0, Math.Round(result[2, 2], 12));
            Assert.AreEqual(0.0, Math.Round(result[2, 0], 12));
            Assert.AreEqual(0.0, Math.Round(result[1, 0], 12));
            Assert.AreEqual(0.0, Math.Round(result[2, 1], 12));
            Assert.AreEqual(0.0, Math.Round(result[2, 0], 12));
            Assert.AreEqual(0.0, Math.Round(result[1, 2], 12));
            Assert.AreEqual(0.0, Math.Round(result[0, 1], 12));
        }

        [TestMethod]
        public void TestMethod24()
        {
            Matrix matrixA = new Matrix(new double[,] { { 2, 1, -1, 8 }, { -3, -1, 2, -11 }, { -2, 1, 2, -3 } });
            Matrix result = matrixA.GaussianElimination();
            Assert.AreEqual(1.0, Math.Round(result[0, 0], 12));
            Assert.AreEqual(1.0, Math.Round(result[1, 1], 12));
            Assert.AreEqual(1.0, Math.Round(result[2, 2], 12));
            Assert.AreEqual(4.0, Math.Round(result[0, 3], 12));
            Assert.AreEqual(2.0, Math.Round(result[1, 3], 12));
            Assert.AreEqual(-1.0, Math.Round(result[2, 3], 12));
        }

        [TestMethod]
        public void TestMethod25()
        {
            Matrix matrixA = new Matrix(new double[,] { { 1, 3, -5, 2, 94 }, { 4, -3, 1, 5, 58 }, { 6, -2, 2, 4, 72 }, { 0, 2, 3, -7, -69 } });
            Matrix result = matrixA.GaussianElimination();
            Assert.AreEqual(1.0, Math.Round(result[0, 0], 12));
            Assert.AreEqual(1.0, Math.Round(result[1, 1], 12));
            Assert.AreEqual(1.0, Math.Round(result[2, 2], 12));
            Assert.AreEqual(1.0, Math.Round(result[3, 3], 12));
            Assert.AreEqual(94.0, Math.Round(result[0, 4], 12));
            Assert.AreEqual(21.2, Math.Round(result[1, 4], 12));
            Assert.AreEqual(-17.0, Math.Round(result[2, 4], 12));
            Assert.AreEqual(8.0, Math.Round(result[3, 4], 12));
        }

        [TestMethod]
        public void TestMethod26()
        {
            Matrix matrixA = new Matrix(new double[,] { { -1, 2, 0, 0, 3 }, { 2, -4, 1, 3, -4 }, { 1, -2, 3, 9, 3 }, { -2, 4, 2, 6, 10 } });
            Matrix result = matrixA.GaussianElimination();
            Assert.AreEqual(1.0, Math.Round(result[0, 0], 12));
            Assert.AreEqual(-3, Math.Round(result[0, 4], 12));

        }

    }
}