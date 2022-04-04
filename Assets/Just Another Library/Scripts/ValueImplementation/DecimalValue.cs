using UnityEngine;

namespace JAL
{
    [System.Serializable]
    public class DecimalValue : AbstractValue<float>
    {
        public DecimalValue(string name, float variable, string Group)
        : base(name, variable, Group) { }

        public DecimalValue(string name, float variable, string Group, string SubGroup)
        : base(name, variable, Group, SubGroup) { }
        
        public DecimalValue(string name, float variable) : base(name, variable) { }
        public override ValueType GetValueType() => ValueType.Decimal;
        public override float ValueConversion(float variable) => variable;
    }
}

