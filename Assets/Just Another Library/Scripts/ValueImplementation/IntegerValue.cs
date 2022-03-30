using System;
using UnityEngine;

namespace JAL.UI
{
    [System.Serializable]
    public class IntegerValue : AbstractValue<int>
    {
        public IntegerValue(string name, int variable) : base(name, variable){ }
        public override ValueType GetValueType() => ValueType.Integer;
        public override int ValueConversion(int variable) => variable; 
    }
}

