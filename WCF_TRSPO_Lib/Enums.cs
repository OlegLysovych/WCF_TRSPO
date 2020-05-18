using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WCF_TRSPO_Lib
{
   // [DataContract]
   // [Flags]
    public enum MatrixEnum
    {
        [EnumMember]
        A,
        [EnumMember]
        A2,
        [EnumMember]
        A1,
        [EnumMember]
        B1,
        [EnumMember]
        C2,
        [EnumMember]
        B2
    }
   // [DataContract]
   // [Flags]
    public enum VectorEnum
    {
        [EnumMember]
        b,
        [EnumMember]
        b1,
        [EnumMember]
        c1
    }
}