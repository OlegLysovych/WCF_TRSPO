using MathNet.Numerics.LinearAlgebra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace WCF_TRSPO_Lib
{
    [DataContract]
    [ServiceBehavior(AddressFilterMode = AddressFilterMode.Any)]
    [KnownType(typeof(Matrix<double>))]
    [KnownType(typeof(Vector<double>))]
    [KnownType(typeof(ObjectObgortka))]
    public class ObjectObgortka
    {
        public ObjectObgortka()
        {
            _Matrix = null;
            _Vector = null;
        }
        [DataMember]
        public Matrix<double> _Matrix;
        [DataMember]
        public Vector<double> _Vector;
        [DataMember]
        public Vector<double> com1;

        [DataMember]
        public Matrix<double> Matrix { get { return _Matrix; } set { _Matrix = value; } }
        [DataMember]
        public Vector<double> Vector { get { return _Vector; } set { _Vector = value; } }
        [DataMember]
        public Vector<double> compileY1 { get { return _Vector; } set { _Vector = value; } }
        [DataMember]
        public Vector<double> compileY2 { get { return _Vector; } set { _Vector = value; } }
        [DataMember]
        public Matrix<double> compileY3 { get { return _Matrix; } set { _Matrix = value; } }
        [DataMember]
        public Vector<double> mainThreadCalculating { get { return _Vector; } set { _Vector = value; } }
    }
}
