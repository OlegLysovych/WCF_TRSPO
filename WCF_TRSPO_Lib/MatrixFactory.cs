using MathNet.Numerics.LinearAlgebra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Web;

namespace WCF_TRSPO_Lib
{
    
    
    public class MatrixFactory
    {

        public Matrix<double> GetMatrix(MatrixEnum en, int count)
        {
            switch (en)
            {
                case MatrixEnum.A:
                    return GetSquareRandomMatrix(count);
                case MatrixEnum.A1:
                    return GetSquareRandomMatrix(count);
                case MatrixEnum.B2:
                    return GetSquareRandomMatrix(count);
                case MatrixEnum.A2:
                    return GetSquareRandomMatrix(count);
                case MatrixEnum.C2:
                    return GetC2Matrix(count);
                default:
                    return null;
            }
        }

        public Matrix<double> GetC2Matrix(int n)
        {
            var matrix = Matrix<double>.Build.Dense(n, n);
            for (int i = 0; i < matrix.RowCount; i++)
            {
                for (int j = 0; j < matrix.ColumnCount; j++)
                {
                    matrix[i, j] = 21 / (Math.Pow(i, 2) - (2 * j) + 0.00001);
                }
            }
            Console.WriteLine("factory:");
            Console.WriteLine(matrix);
            return matrix;
        }

        public Matrix<double> GetSquareRandomMatrix(int n)
        {
            Random r = new Random();
            var matrix = Matrix<double>.Build.Dense(n, n);
            for (int i = 0; i < matrix.RowCount; i++)
            {
                for (int j = 0; j < matrix.ColumnCount; j++)
                {
                    matrix[i, j] = r.Next(0, n);
                    //Console.WriteLine(matrix[i, j]);
                }
            }
            //Console.WriteLine(matrix);
            return matrix;
        }

    }
}