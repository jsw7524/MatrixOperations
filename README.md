# JSW MatrixOperations

A light-weight matrix operations library for C#, supports matrix addition, matrix mulitplication, vector addition, dot product, cross product and using CPU cores-corresponding threads as many as possible to parallelly compute result.Beside that, matrix operations can be writen in easy understanding way like regular math expression.

#### fluent matrix operations
```C#
        public void TestMethod()
        {
            Matrix identityMatrix1 = MatrixHelper.GetIdentityMatrix(2);
            Matrix result = identityMatrix1 + 2.0 * identityMatrix1 + 3.0 * identityMatrix1;
        }
```

#### fluent vector operations
```C#
        public void TestMethod()
        {
            Vector a = new Vector(new double[3] { 1, 2, 3 });
            Vector b = new Vector(new double[3] { 4, 5, 6 });
            Vector result = new Vector(2.0 * a + 3.0 * b);
        }
```
#### vector addition
```C#
        public void TestMethod()
        {
            Vector a = new Vector(new double[3] { 1, 2, 3 });
            Vector b = new Vector(new double[3] { 4, 5, 6 });
            Vector result = a + b;
        }
```

#### Get Vector elemet
```C#
        public void TestMethod()
        {
            Vector a = new Vector(new double[3] { 1, 2, 3 });
            Vector b = new Vector(new double[3] { 4, 5, 6 });
            Vector result = a + b;
            Assert.AreEqual(5.0, result[0]);
            Assert.AreEqual(7.0, result[1]);
            Assert.AreEqual(9.0, result[2]);
        }
```

#### Get Matrix elemet
```C#
        public void TestMethod()
        {
            Matrix matrixA = new Matrix(new double[2, 2] { { 0, 1 }, { 0, 0 } });
            Matrix matrixB = new Matrix(new double[2, 2] { { 0.0, 0.0 }, { 1.0, 0.0 } });
            Matrix result = matrixA + matrixB;
            Assert.AreEqual(0.0, result[0, 0]);
            Assert.AreEqual(1.0, result[0, 1]);
            Assert.AreEqual(1.0, result[1, 0]);
            Assert.AreEqual(0.0, result[1, 1]);
        }
```

#### Create 3x3 Identity Matrix
```C#
        public void TestMethod()
        {
            Matrix identityMatrix1 = MatrixHelper.GetIdentityMatrix(3);
        }
```

#### Matrix transpose
```C#
        public void TestMethod()
        {
            Matrix matrixA = new Matrix(new double[2, 3] { { 1, 2, 3 }, { 4, 5, 6 } });
            Matrix result = matrixA.T;
        }
```

#### 2x2 Matrix Mulitplication
```C#
        public void TestMethod()
        {
            Matrix identityMatrix = MatrixHelper.GetIdentityMatrix(2);
            Matrix randomMatrix = MatrixHelper.GetRandomMatrix(2, 2);
            Matrix result = identityMatrix * randomMatrix;
        }
```

#### 1000x1000 Matrix Mulitplication loaded from Json format
```C#
        public void TestMethod()
        {
            Matrix matrix1 = MatrixHelper.MatrixFromJson(File.ReadAllText("MatrixA1000"));
            Matrix matrix2 = MatrixHelper.MatrixFromJson(File.ReadAllText("MatrixB1000"));
            Matrix result = matrix1 * matrix2;
        }
```

#### dot product
```C#
        public void TestMethod()
        {
            Vector a = new Vector(new double[3] { 1, 2, 3 });
            Vector b = new Vector(new double[3] { 4, 5, 6 });
            double result = a * b;
        }
```

#### linear transformation
```C#
        public void TestMethod()
        {
            Matrix matrixA = new Matrix(new double[2, 3] { { 1, 0, -1 }, { 3, 1, 2 } });
            Vector b = new Vector(new double[3] { 1, 2, 3 });
            Vector result = matrixA * b;
        }
```