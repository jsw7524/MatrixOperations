using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyApp;
using Newtonsoft.Json;

namespace TestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Matrix identityMatrix1 = MatrixOperations.GetIdentityMatrix(3);
            Matrix identityMatrix2 = MatrixOperations.GetIdentityMatrix(3);
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
            Matrix identityMatrix = MatrixOperations.GetIdentityMatrix(2);
            Matrix randomMatrix = MatrixOperations.GetRandomMatrix(2, 2);
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


    }
}