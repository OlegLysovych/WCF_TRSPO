using MathNet.Numerics.LinearAlgebra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WCF_TRSPO_Lib
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {       

        [OperationContract]
        [ServiceKnownType(typeof(ObjectObgortka))]
        [ServiceKnownType(typeof(Matrix<double>))]
        [ServiceKnownType(typeof(Vector<double>))]
        ObjectObgortka GetMatrixData(int n, MatrixEnum Letter);

        [OperationContract]
        [ServiceKnownType(typeof(ObjectObgortka))]
        [ServiceKnownType(typeof(Matrix<double>))]
        [ServiceKnownType(typeof(Vector<double>))]
        ObjectObgortka GetVectorData(int n, VectorEnum Letter);

        [OperationContract]
        [ServiceKnownType(typeof(ObjectObgortka))]
        [ServiceKnownType(typeof(Matrix<double>))]
        [ServiceKnownType(typeof(Vector<double>))]
        ObjectObgortka CompileY1(Vector<double> vectorB, Matrix<double> matrixA);

        [OperationContract]
        [ServiceKnownType(typeof(ObjectObgortka))]
        [ServiceKnownType(typeof(Matrix<double>))]
        [ServiceKnownType(typeof(Vector<double>))]
        ObjectObgortka CompileY2(Vector<double> vectorC1, Matrix<double> matrixA1, Vector<double> vectorB1);

        [OperationContract]
        [ServiceKnownType(typeof(ObjectObgortka))]
        [ServiceKnownType(typeof(Matrix<double>))]
        [ServiceKnownType(typeof(Vector<double>))]
        ObjectObgortka CompileY3(Matrix<double> matrixA2, Matrix<double> matrixB2, Matrix<double> matrixC2);

        [OperationContract]
        [ServiceKnownType(typeof(ObjectObgortka))]
        [ServiceKnownType(typeof(Matrix<double>))]
        [ServiceKnownType(typeof(Vector<double>))]
        ObjectObgortka MainThreadCalculating(int n, Matrix<double> matrixY3, Vector<double> vectorY2, Vector<double> vectorY1);
        //[OperationContract]
        //Matrix<double> GetMatrixData(int n, string Letter);

        //[OperationContract]
        //Vector<double> GetVectorData(int n, string Letter);

        //[OperationContract]
        //CompositeType GetDataUsingDataContract(CompositeType composite);

        // TODO: Add your service operations here
    }


    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    //[DataContract]
    //public class CompositeType
    //{
    //    bool boolValue = true;
    //    string stringValue = "Hello ";

    //    [DataMember]
    //    public bool BoolValue
    //    {
    //        get { return boolValue; }
    //        set { boolValue = value; }
    //    }

    //    [DataMember]
    //    public string StringValue
    //    {
    //        get { return stringValue; }
    //        set { stringValue = value; }
    //    }
    //}
}
