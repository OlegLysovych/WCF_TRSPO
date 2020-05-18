using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics;
using System;
using System.Linq;
using System.Numerics;
using System.Threading;
using System.IO;
using System.ServiceModel;

namespace WCF_TRSPO_Lib
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    [ServiceBehavior(AddressFilterMode = AddressFilterMode.Any)]
    public class Service1 : IService1
    {
        //public Matrix<double> GetMatrixData(int n, string Letter)
        //{
        //    var matrix = Matrix<double>.Build.Dense(n, n);
        //    string input = Letter;// @"C:\Users\PC\source\repos\Lab2_TRSPO_Paralel\Lab2_TRSPO_Paralel\bin\Debug\netcoreapp3.1\matrixA.txt";
        //    //StreamReader reader = new StreamReader(input);
        //    using (var reader = new StreamReader(input))
        //    {
        //        for (var i = 0; i < n; i++)
        //        {
        //            for (var j = 0; j < n; j++)
        //            {
        //                string line;
        //                //if ((line = reader.ReadAsync()) != null)
        //                //{
        //                    matrix[i, j] = reader.Read();
        //                    Console.WriteLine($"index {i}{j}, Line: {matrix[i, j]}");
        //                    //matrix[i, j] = Convert.ToDouble(line);
        //                //}
        //            }
        //            reader.ReadLine();
        //        }                
        //    }
        //    using (TextWriter tw = new StreamWriter("matrixARew.txt"))
        //    {
        //        for (int i = 0; i < n; i++)
        //        {
        //            for (int j = 0; j < n; j++)
        //            {
        //                tw.Write(matrix[i, j]);
        //            }
        //            tw.WriteLine();
        //        }
        //    }
        //    return matrix;
        //}
        //public Vector<double> GetVectorData(int n, string Letter)
        //{
        //    var vector = Vector<double>.Build.Dense(n);
        //    string input = Letter;// @"C:\Users\PC\source\repos\Lab2_TRSPO_Paralel\Lab2_TRSPO_Paralel\bin\Debug\netcoreapp3.1\matrixA.txt";
        //    //StreamReader reader = new StreamReader(input);
        //    using (var reader = new StreamReader(input))
        //    {
        //        for (var i = 0; i < n; i++)
        //        {                 
        //            string line;
        //            if ((line = reader.ReadLine()) != null)
        //            {
        //                Console.WriteLine($"Loop index {i + n * i}, Line: {line}");
        //                vector[i] = Convert.ToDouble(line);
        //            }                    
        //        }                
        //    }
        //    return vector;
        //}
        
        public ObjectObgortka GetMatrixData(int n, MatrixEnum Letter)
        {
            MatrixFactory matrixFactory = new MatrixFactory();
            
            ObjectObgortka obgortka = new ObjectObgortka();
            Console.WriteLine(n);
            obgortka.Matrix = matrixFactory.GetMatrix(Letter, n);
            //obgortka.Matrix = null;
            Console.WriteLine("obgortka");
            Console.WriteLine(obgortka.Matrix);
            return obgortka;                   
        }
        public ObjectObgortka GetVectorData(int n, VectorEnum Letter)
        {
            VectorFactory vectorFactory = new VectorFactory();
            ObjectObgortka obgortka = new ObjectObgortka();
            obgortka.Vector = vectorFactory.GetVector(Letter, n);
            return obgortka;                
        }

        public ObjectObgortka CompileY1(Vector<double> vectorB, Matrix<double> matrixA)
        {
            ObjectObgortka obgortka = new ObjectObgortka();
            var compileY1 = matrixA * vectorB;
            obgortka.compileY1 = compileY1;
            return obgortka;
        }
        public ObjectObgortka CompileY2(Vector<double> vectorC1, Matrix<double> matrixA1, Vector<double> vectorB1)
        {
            ObjectObgortka obgortka = new ObjectObgortka();
            var compileY2 = matrixA1 * (vectorB1 + (20 * vectorC1));
            obgortka.compileY2 = compileY2;
            return obgortka;
        }
        public ObjectObgortka CompileY3(Matrix<double> matrixA2, Matrix<double> matrixB2, Matrix<double> matrixC2)
        {
            ObjectObgortka obgortka = new ObjectObgortka();
            var compileY3 = (matrixA2 * matrixB2) - matrixC2;
            obgortka.compileY3 = compileY3;
            return obgortka;
        }

    public ObjectObgortka MainThreadCalculating(int n, Matrix<double> matrixY3, Vector<double> vectorY2, Vector<double> vectorY1)
        {
            Vector<double> vectorResult = Vector<double>.Build.Dense(n);
            Thread mainThread = new Thread(() =>
            {
                Console.WriteLine("Main\n");
                Vector<double> firstMainAdd = Vector<double>.Build.Dense(n);

                Matrix<double> secondMainAdd = Matrix<double>.Build.Dense(n, n);

                Thread forFirstMainAdd = new Thread(() =>
                {
                    Console.WriteLine("Scopes\n");
                    Vector<double> firstAddition = Vector<double>.Build.Dense(n);

                    Vector<double> secondAddition = Vector<double>.Build.Dense(n);

                    Vector<double> thirdAddition = Vector<double>.Build.Dense(n);

                    Thread forFirstAdd = new Thread(() =>
                    {
                        Console.WriteLine("FirstAddition\n");
                        Matrix<double> firstMul = Matrix<double>.Build.Dense(n, n);

                        Thread FirstAddition = new Thread(() =>
                        {
                            Console.WriteLine("MatrixSQR");
                            firstMul = matrixY3 * matrixY3;
                            //Console.WriteLine(firstMul);
                        });

                        FirstAddition.Start();
                        FirstAddition.Join();

                        firstAddition = firstMul * vectorY2;
                        //Console.WriteLine("FirstAddition",firstAddition);                        
                    });

                    Thread forSecondAdd = new Thread(() =>
                    {
                        Console.WriteLine("SecondAddition\n");

                        Vector<double> firstMul = Vector<double>.Build.Dense(n);
                        Thread SecondAddition = new Thread(() =>
                        {
                            Console.WriteLine("MatrixToVector");
                            firstMul = matrixY3 * vectorY1;
                        });

                        SecondAddition.Start();
                        SecondAddition.Join();

                        secondAddition = firstMul;
                        //Console.WriteLine("secondAddition",secondAddition);
                    });

                    Thread forThirdAdd = new Thread(() =>
                    {
                        Console.WriteLine("ThirdAddition\n");

                        double FirstPartOfAddition = 0.0;
                        Vector<double> SecondPartOfAddition = Vector<double>.Build.Dense(n);

                        Thread TFirstPartOfAddition = new Thread(() =>
                        {
                            Console.WriteLine("VectorToVector");
                            FirstPartOfAddition = vectorY2 * vectorY2;
                        });

                        Thread TSecondPartOfAddition = new Thread(() =>
                        {
                            Console.WriteLine("MatrixToVector");
                            SecondPartOfAddition = matrixY3 * vectorY1;
                        });

                        TFirstPartOfAddition.Start();
                        TSecondPartOfAddition.Start();
                        TFirstPartOfAddition.Join();
                        TSecondPartOfAddition.Join();

                        thirdAddition = FirstPartOfAddition * SecondPartOfAddition;
                    });

                    forFirstAdd.Start();
                    forSecondAdd.Start();
                    forThirdAdd.Start();

                    forFirstAdd.Join();
                    forSecondAdd.Join();
                    forThirdAdd.Join();

                    firstMainAdd = firstAddition + secondAddition + thirdAddition;
                    //Console.WriteLine("firstMainAdd equalsssss", firstMainAdd[1]);
                });

                Thread forSecondMainAdd = new Thread(() =>
                {
                    Console.WriteLine("AfterScopes\n");
                    Matrix<double> FirstMul = Matrix<double>.Build.Dense(n, n);
                    Thread LastMatrixSQR = new Thread(() =>
                    {
                        Console.WriteLine("LastMatrixSQR");
                        FirstMul = matrixY3 * matrixY3;

                    });
                    LastMatrixSQR.Start();
                    LastMatrixSQR.Join();
                    //Console.WriteLine(FirstMul);
                    secondMainAdd = FirstMul;
                });

                forFirstMainAdd.Start();
                forSecondMainAdd.Start();

                forFirstMainAdd.Join();
                forSecondMainAdd.Join();
                Console.WriteLine("\nMatrix:");
                Console.WriteLine(secondMainAdd);
                Console.WriteLine("\nVector");
                Console.WriteLine(firstMainAdd);
                vectorResult = firstMainAdd * secondMainAdd;
            });
            mainThread.Start();
            mainThread.Join();
            Console.WriteLine("\nVECTOR ROW");
            for (int i = 0; i < vectorResult.Count; i++)
            {
                Console.Write(vectorResult[i] + " ");
            }
            return new ObjectObgortka { mainThreadCalculating = vectorResult };
        }
        //public string GetData(int value)
        //{
        //    return string.Format("You entered: {0}", value);
        //}

        //public CompositeType GetDataUsingDataContract(CompositeType composite)
        //{
        //    if (composite == null)
        //    {
        //        throw new ArgumentNullException("composite");
        //    }
        //    if (composite.BoolValue)
        //    {
        //        composite.StringValue += "Suffix";
        //    }
        //    return composite;
        //}
    }
}
