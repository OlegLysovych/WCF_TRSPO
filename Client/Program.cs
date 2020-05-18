using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Client.ServiceReference1;
using System.Threading.Tasks;
using WCF_TRSPO_Lib;
using MathNet.Numerics.LinearAlgebra;

namespace Client
{
    class Program
    {
        public static void Main(string[] args)
        {
            //Step 1: Create an instance of the WCF proxy.
            Service1Client client = new Service1Client();
            Obgortka obgortka = new Obgortka();
            ObjectObgortka objectobgortka = new ObjectObgortka();
            // Step 2: Call the service operations.
            // Call the Add service operation.
            Console.Write("N: ");
            int n = Convert.ToInt32(Console.ReadLine());
            objectobgortka = client.GetMatrixData(n, MatrixEnum.A);            
            obgortka.MatrixA = objectobgortka.Matrix;
            objectobgortka = client.GetMatrixData(n, MatrixEnum.A1);
            Matrix<double> MatrixA1 = objectobgortka.Matrix;
            var matrixA2 = client.GetMatrixData(n, MatrixEnum.A2);
            Matrix<double> MatrixA2 = matrixA2.Matrix;
            var matrixB2 = client.GetMatrixData(n, MatrixEnum.B2);
            Matrix<double> MatrixB2 = matrixB2.Matrix;
            var matrixC2 = client.GetMatrixData(n, MatrixEnum.C2);
            Matrix<double> MatrixC2 = matrixC2.Matrix;
            //Console.WriteLine(MatrixA);

            var vectorB = client.GetVectorData(n, VectorEnum.b);
            Vector<double> VectorB = vectorB.Vector;
            var vectorB1 = client.GetVectorData(n, VectorEnum.b1);
            Vector<double> VectorB1 = vectorB1.Vector;
            var vectorC1 = client.GetVectorData(n, VectorEnum.c1);
            Vector<double> VectorC1 = vectorC1.Vector;
            //for (int i = 0; i < n; i++)
            //{
            //    Console.WriteLine("cc",vectorB.Vector[i]);
            //}
            //var matrixA = client.GetMatrixData(n, @"C:\Users\PC\source\repos\Lab2_TRSPO_Paralel\Lab2_TRSPO_Paralel\bin\Debug\netcoreapp3.1\matrixA.txt");
            //var matrixA1 = client.GetMatrixData(n, @"C:\Users\PC\source\repos\Lab2_TRSPO_Paralel\Lab2_TRSPO_Paralel\bin\Debug\netcoreapp3.1\matrixA1.txt");
            //var matrixA2 = client.GetMatrixData(n, @"C:\Users\PC\source\repos\Lab2_TRSPO_Paralel\Lab2_TRSPO_Paralel\bin\Debug\netcoreapp3.1\matrixA2.txt");
            //var matrixB2 = client.GetMatrixData(n, @"C:\Users\PC\source\repos\Lab2_TRSPO_Paralel\Lab2_TRSPO_Paralel\bin\Debug\netcoreapp3.1\matrixB2.txt");
            //var matrixC2 = client.GetMatrixData(n, @"C:\Users\PC\source\repos\Lab2_TRSPO_Paralel\Lab2_TRSPO_Paralel\bin\Debug\netcoreapp3.1\matrixC2.txt");

            //var vectorB = client.GetVectorData(n, @"C:\Users\PC\source\repos\Lab2_TRSPO_Paralel\Lab2_TRSPO_Paralel\bin\Debug\netcoreapp3.1\vectorB.txt");
            //var vectorB1 = client.GetVectorData(n, @"C:\Users\PC\source\repos\Lab2_TRSPO_Paralel\Lab2_TRSPO_Paralel\bin\Debug\netcoreapp3.1\vectorB1.txt");
            //var vectorC1 = client.GetVectorData(n, @"C: \Users\PC\source\repos\Lab2_TRSPO_Paralel\Lab2_TRSPO_Paralel\bin\Debug\netcoreapp3.1\vectorC1.txt");

            var Y1 = client.CompileY1(VectorB, obgortka.MatrixA);
            Vector<double> vectorY1 = Y1.compileY1;
            var Y2 = client.CompileY2(VectorC1, MatrixA1, VectorB1);
            Vector<double> vectorY2 = Y2.compileY2;
            var Y3 = client.CompileY3(MatrixA2, MatrixB2, MatrixC2);
            Matrix<double> matrixY3 = Y3.compileY3;

            var maincalc = client.MainThreadCalculating(n, matrixY3, vectorY2, vectorY1);
            Vector<double> maincalculate = maincalc.mainThreadCalculating;
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine(maincalculate[i]);
            }

            // Step 3: Close the client to gracefully close the connection and clean up resources.
            Console.WriteLine("\nPress <Enter> to terminate the client.");
            Console.ReadLine();
            client.Close();
        }
        public class Obgortka
        {
            public Matrix<double> _Matrix;
            //[DataMember]
            //public Vector<double> Vector;
            public Matrix<double> MatrixA { get { return _Matrix; } set { _Matrix = value; } }
        }

    }

}
