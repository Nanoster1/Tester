#nullable enable
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tester.DataTypes
{
    public class Matrix: IEnumerable<double>
    {
        private readonly double[] _values;

        public Matrix(IEnumerable<double> source, int rowLengtn, int columnLength)
        {
            RowLengtn = rowLengtn;
            ColumnLength = columnLength;
            double[] values;
            if (source is double[] sourceAr)
                values = sourceAr;
            else
                values = source.ToArray();
            _values = new double[rowLengtn * columnLength];
            Length = _values.Length;
            for (int i = 0; i < rowLengtn * columnLength; i++)
            {
                if (i >= values.Length) _values[i] = 0; 
                else _values[i] = values[i];
            }
        }
        
        public int RowLengtn { get; }
        public  int ColumnLength { get; }
        public  int Length { get; }

        public double[] GetRow(int number)
        {
            if (number <= 0) throw new ArgumentOutOfRangeException(nameof(number));
            var start = (number - 1) * RowLengtn;
            var end = start + RowLengtn;
            var row = new double[RowLengtn];
            Array.Copy(_values, start, row, 0, RowLengtn);
            return row;
        }
        public double[] GetColumn(int number)
        {
            if (number <= 0) throw new ArgumentOutOfRangeException(nameof(number));
            var column = new double[ColumnLength];
            var index = 0;
            for (int i = number - 1; i < _values.Length; i += RowLengtn)
            {
                column[index++] = _values[i];
            }
            return column;
        }
        
        public double this[int row, int column] => _values[row * RowLengtn + column];
        public double this[int index] => _values[index];

        public Matrix Transpose()
        {
            var resultArray = new double[Length];
            var arrayIndex = 0;
            for (int i = 0; i < RowLengtn; i++)
            {
                var column = GetColumn(i);
                for (int j = 0; j < column.Length; j++)
                {
                    resultArray[arrayIndex++] = column[j];
                }
            }
            return new Matrix(resultArray, RowLengtn, ColumnLength);
        }

        public static bool operator ==(Matrix matrix1, Matrix matrix2)
        {
            if (matrix1.Equals(matrix2))
                return true;
            return false;
        }

        public static bool operator !=(Matrix matrix1, Matrix matrix2)
        {
            if (matrix1.Equals(matrix2))
                return false;
            return true;
        }

        public static Matrix operator +(Matrix matrix1, Matrix matrix2)
        {
            if (matrix1.RowLengtn != matrix2.RowLengtn || matrix1.ColumnLength != matrix2.ColumnLength)
                throw new ArgumentException();
            var resultArray = new double[matrix1.Length];
            for (int i = 0; i < matrix1.Length; i++)
            {
                resultArray[i] = matrix1[i] + matrix2[i];
            }
            return new Matrix(resultArray, matrix1.RowLengtn, matrix1.ColumnLength);
        }
        public static Matrix operator -(Matrix matrix1, Matrix matrix2)
        {
            if (matrix1.RowLengtn != matrix2.RowLengtn || matrix1.ColumnLength != matrix2.ColumnLength)
                throw new ArgumentException();
            return matrix1 + -matrix2;
        }
        public static Matrix operator -(Matrix matrix)
        {
            return matrix * -1;
        }
        public static Matrix operator *(Matrix matrix1, Matrix matrix2)
        {
            if (matrix1.RowLengtn != matrix2.ColumnLength) throw new ArgumentException();
            var resultArray = new double[matrix1.ColumnLength * matrix2.RowLengtn];
            Enumerable.Range(0, matrix1.ColumnLength).AsParallel()
                .ForAll(i =>
                {
                    for (int j = 0; j < matrix2.RowLengtn; j++)
                    {
                        var result = 0d;
                        for (int k = 0; k < matrix1.RowLengtn; k++)
                        {
                            result += matrix1[i, k] * matrix2[k, j];
                        }
                        resultArray[i * matrix1.RowLengtn + j] = result;
                    }
                });
            return new Matrix(resultArray, matrix1.ColumnLength, matrix2.RowLengtn);
        }
        public static Matrix operator *(Matrix matrix, double multiplier)
        {
            var resultArray = new double[matrix.Length];
            for (int i = 0; i < matrix.Length; i++)
            {
                resultArray[i] = matrix[i] * multiplier;
            }
            return new Matrix(resultArray, matrix.ColumnLength, matrix.RowLengtn);
        }
        public static Matrix operator *(Matrix matrix, int multiplier)
        {
            return matrix * (double)multiplier;
        }
        public static Matrix operator *(Matrix matrix, double[] vector)
        {
            var resultArray = new double[vector.Length];
            for (int i = 0; i < vector.Length; i++)
            {
                var row = matrix.GetRow(i);
                var result = 0d;
                for (int j = 0; j < row.Length; j++)
                {
                    result += row[j] * vector[j];
                }
                resultArray[i] = result;
            }
            return new Matrix(resultArray, 1, vector.Length);
        }
        public static Matrix operator *(Matrix matrix, int[] vector)
        {
            return matrix * vector.Select(x => (double)x).ToArray();
        }
        public static double[,] RandomMatrix(int size)
		{
            var random = new Random();
            double[,] matrix = new double[size,size];
			for (int i = 0; i < size; i++)
			{
				for (int j = 0; j < size; j++)
				{
                    matrix[i,j] = random.Next(0, int.MaxValue);
				}
			}
            return matrix;
		}
        public override string ToString()
        {
            var @string = new StringBuilder();
            for (int i = 0; i < _values.Length; i++)
            {
                @string.Append(_values[i]);
                if ((i + 1) % RowLengtn == 0)
                    @string.AppendLine();
            }
            return @string.ToString();
        }
        public override bool Equals(object? obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            else if (ReferenceEquals(this, obj)) return true;
            else if (obj.GetType() != this.GetType()) return false;
            return obj.GetHashCode() == this.GetHashCode();
        }
        public override int GetHashCode()
        {
            return int.Parse(string.Join('0', _values.Select(x => (int)x)));
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        public IEnumerator<double> GetEnumerator()
        {
            return (IEnumerator<double>)_values.GetEnumerator();
        }

    }
}
