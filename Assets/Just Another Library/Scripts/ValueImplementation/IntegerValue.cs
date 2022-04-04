using System;
using UnityEngine;

namespace JAL
{
    [System.Serializable]
    public class IntegerValue : AbstractValue<int>
    {
        public IntegerValue(string name, int variable) : base(name, variable) { }

        public IntegerValue(string name, int variable, string Group)
        : base(name, variable, Group) { }

        public IntegerValue(string name, int variable, string Group, string SubGroup)
        : base(name, variable, Group, SubGroup) { }

        public override ValueType GetValueType() => ValueType.Integer;
        public override int ValueConversion(int variable) => variable;
    }
}

