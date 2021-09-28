using Algorithms.FirstTask;
using System;
using Tester.Meta.Interfaces;
using Tester.Meta.Models;
using Tester.Meta.Testers;
using Xunit;

namespace Tester.XUnitTests
{
	public class MatrixAlgorithmTests
	{
		[Fact]
		public void TestMatrixMulAlgorithm()
		{
			var matrixA = new double[2, 2] { { 1, 2 }, { 1, 2 } };
			var matrixB = new double[2, 2] { { 2, 1 }, { 2, 1 } };
			var newMAtrix = MatrixMul.MulMatrix(matrixA, matrixB);
			var result = new double[2, 2] { { 6, 3 }, { 6, 3 } };
			Assert.Equal(newMAtrix, result);
		}
		[Fact]
		public void TestMatrixAddAlgorithm()
		{
			var matrixA = new Matrix(new double[] { 1, 2, 1, 2 }, 2, 2);
			var matrixB = new Matrix(new double[] { 2, 1, 2, 1 }, 2, 2);
			var matrix = matrixA + matrixB;
			var result = new double[2, 2] { { 3, 3 }, { 3, 3 } };
			Assert.Equal(matrix.To2DArray(), result);
		}
		[Fact]
		public void TestMatrixSubAlgorithm()
		{
			var matrixA = new Matrix(new double[] { 3, 3, 3, 3 }, 2, 2);
			var matrixB = new Matrix(new double[] { 2, 1, 2, 1 }, 2, 2);
			var matrix = matrixA - matrixB;
			var result = new double[2, 2] { { 1, 2 }, { 1, 2 } };
			Assert.Equal(matrix.To2DArray(), result);
		}
		[Fact]
		public void TestMatrixEqualsAlgorithm()
		{
			var matrixA = new Matrix(new double[] { 3, 3, 3, 3 }, 2, 2);
			var matrixB = new Matrix(new double[] { 2, 1, 2, 1 }, 2, 2);		
			var matrixC = new Matrix(new double[] { 2, 1, 2, 1 }, 2, 2);

			Assert.False(matrixA != matrixB);
			Assert.True(matrixC==matrixB);
		}
		[Fact]
		public void TestMatrixMulOnNumAlgorithm()
		{
			var matrixA = new Matrix(new double[] { 2, 2, 2, 2 }, 2, 2);
			var matrix = matrixA * 5;
			var result = new double[2, 2] { { 10, 10 }, { 10, 10 } };
			Assert.Equal(matrix.To2DArray(), result);
		}
		[Fact]
		public void MatrixMulAlgTest()
		{
			BigTestMatrixAlgorithm((x, y) => MatrixMul.MulMatrix(x, y), nameof(MatrixMul), 5);
		}
		private static void BigTestMatrixAlgorithm(Func<double[,], double[,], double[,]> function, string name, int interationCount)
		{
			ITester<long> tester = new MemoryTester();
			ITester<double> tester2 = new TimeTester();
			for (int i = 0; i < 2000; i++)
			{
				var matrixA = Matrix.RandomMatrix(i);
				var matrixB = Matrix.RandomMatrix(i);
				tester.Test(() => function.Invoke(matrixA, matrixB), interationCount, name);
				tester2.Test(() => function.Invoke(matrixA, matrixB), interationCount, name);
			}
			VectorAlgorithmTests.SaveResult(tester, tester2);
		}
	}
}
