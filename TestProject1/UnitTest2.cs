using Microsoft.VisualStudio.TestTools.UnitTesting;
using JswMatrix;
using Newtonsoft.Json;
using System.IO;

namespace TestProject1
{
    [TestClass]
    public class UnitTest2
    {
        [TestMethod]
        public void TestMethod1()
        {
            Matrix matrix1 = MatrixHelper.MatrixFromJson(File.ReadAllText("MatrixA1000"));
            Matrix matrix2 = MatrixHelper.MatrixFromJson(File.ReadAllText("MatrixB1000"));
            Matrix expectedMatrix = MatrixHelper.MatrixFromJson(File.ReadAllText("MatrixMulResult1000"));
            Matrix result = matrix1 * matrix2;

            Assert.AreEqual(expectedMatrix[0, 0], result[0, 0]);
            Assert.AreEqual(expectedMatrix[12, 53], result[12, 53]);
            Assert.AreEqual(expectedMatrix[62, 29], result[62, 29]);
            Assert.AreEqual(expectedMatrix[88, 42], result[88, 42]);

        }

        [TestMethod]
        public void TestMethod2()
        {
            Matrix matrix1 = MatrixHelper.MatrixFromJson(File.ReadAllText("MatrixA1000"));
            Matrix matrix2 = MatrixHelper.MatrixFromJson(File.ReadAllText("MatrixB1000"));
            Matrix expectedMatrix = MatrixHelper.MatrixFromJson(File.ReadAllText("MatrixAddResult1000"));
            Matrix result = matrix1 + matrix2;
            //File.WriteAllText("MatrixAddResult1000", JsonConvert.SerializeObject(result));
            Assert.AreEqual(expectedMatrix[0, 0], result[0, 0]);
            Assert.AreEqual(expectedMatrix[12, 53], result[12, 53]);
            Assert.AreEqual(expectedMatrix[62, 29], result[62, 29]);
            Assert.AreEqual(expectedMatrix[88, 42], result[88, 42]);

        }


        [TestMethod]
        public void TestMethod3()
        {
            //Multi threads
            //Matrix.matrixOperator = MatrixOperationsMT.Instance;
            Matrix matrix1 = MatrixHelper.MatrixFromJson(File.ReadAllText("MatrixA1000"));
            Matrix matrix2 = MatrixHelper.MatrixFromJson(File.ReadAllText("MatrixB1000"));
            Matrix expectedMatrix = MatrixHelper.MatrixFromJson(File.ReadAllText("MatrixMulResult1000"));
            Matrix result = matrix1 * matrix2;

            Assert.AreEqual(expectedMatrix[0, 0], result[0, 0]);
            Assert.AreEqual(expectedMatrix[12, 53], result[12, 53]);
            Assert.AreEqual(expectedMatrix[62, 29], result[62, 29]);
            Assert.AreEqual(expectedMatrix[88, 42], result[88, 42]);

        }


        [TestMethod]
        public void TestMethod4()
        {
            //Multi threads
            //Matrix.matrixOperator = MatrixOperationsMT.Instance;
            Matrix matrix1 = MatrixHelper.MatrixFromJson(File.ReadAllText("MatrixA1000"));
            Matrix matrix2 = MatrixHelper.MatrixFromJson(File.ReadAllText("MatrixB1000"));
            Matrix expectedMatrix = MatrixHelper.MatrixFromJson(File.ReadAllText("MatrixAddResult1000"));
            Matrix result = matrix1 + matrix2;
            Assert.AreEqual(expectedMatrix[0, 0], result[0, 0]);
            Assert.AreEqual(expectedMatrix[12, 53], result[12, 53]);
            Assert.AreEqual(expectedMatrix[62, 29], result[62, 29]);
            Assert.AreEqual(expectedMatrix[88, 42], result[88, 42]);

        }

        [TestMethod]
        public void TestMethod5()
        {
            //Multi threads
            //Matrix.matrixOperator = MatrixOperationsMT.Instance;
            Matrix identityMatrix1 = MatrixHelper.GetIdentityMatrix(1000);
            Matrix result = identityMatrix1 + 2.0 * identityMatrix1 + 3.0 * identityMatrix1;
            Assert.AreEqual(6.0, result[0, 0]);
            Assert.AreEqual(0.0, result[0, 1]);
            Assert.AreEqual(0.0, result[1, 0]);
            Assert.AreEqual(6.0, result[1, 1]);
            Assert.AreEqual(6.0, result[500, 500]);
            Assert.AreEqual(6.0, result[800, 800]);
            Assert.AreEqual(0.0, result[436, 746]);
            Assert.AreEqual(0.0, result[7, 382]);
            Assert.AreEqual(0.0, result[793, 88]);
            Assert.AreEqual(0.0, result[1, 986]);
            Assert.AreEqual(0.0, result[639, 192]);
        }
        [TestMethod]
        public void TestMethod6()
        {
            //Multi threads
            Matrix identityMatrix = MatrixHelper.GetIdentityMatrix(11);
            double result = identityMatrix.Determinant();
            Assert.AreEqual(1.0, result);
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
