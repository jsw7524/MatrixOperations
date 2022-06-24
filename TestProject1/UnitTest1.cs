using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyApp;
using Newtonsoft.Json;
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
            Matrix matrixA = new Matrix(new double[2, 3] { { 1, 0, -1 }, { 3, 1, 2 } });
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

        //[TestMethod]
        //public void TestMethodMatrix100()
        //{
        //    int n = 1000;
        //    Matrix randomMatrixA = MatrixHelper.GetRandomMatrix(n, n);
        //    Matrix randomMatrixB = MatrixHelper.GetRandomMatrix(n, n);
        //    Matrix result = randomMatrixA * randomMatrixB;
        //    File.WriteAllText("MatrixA1000", JsonConvert.SerializeObject(randomMatrixA));
        //    File.WriteAllText("MatrixB1000", JsonConvert.SerializeObject(randomMatrixB));
        //    File.WriteAllText("MatrixResult100", JsonConvert.SerializeObject(result));
        //}


    }
}