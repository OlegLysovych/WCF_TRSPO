using MathNet.Numerics.LinearAlgebra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Web;

namespace WCF_TRSPO_Lib
{
    
    public class VectorFactory
    {
        public Vector<double> GetVector(VectorEnum en, int count)
        {
            switch (en)
            {
                case VectorEnum.b:
                    return GetBVector(count);
                case VectorEnum.b1:
                    return GetRandomVector(count);
                case VectorEnum.c1:
                    return GetRandomVector(count);
                default:
                    return null;
            }
        }

        private Vector<double> GetBVector(int count)
        {
            var vector = Vector<double>.Build.Dense(count);
            for (int i = 1; i < vector.Count; i++)
            {
                vector[i] = 21 / (Math.Pow(i, 4));
                //
            }
            Console.WriteLine(vector);
            return vector;
        }

        public Vector<double> GetRandomVector(int n)
        {
            Random r = new Random();
            var vector = Vector<double>.Build.Dense(n);

            for (int i = 0; i < vector.Count; i++)
            {
                vector[i] = r.Next(0, n);
            }
            //Console.WriteLine(vector);
            return vector;
        }
    }
}