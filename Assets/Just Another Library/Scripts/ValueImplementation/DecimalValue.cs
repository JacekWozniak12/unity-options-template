using UnityEngine;

namespace JAL.UI
{
    [System.Serializable]
    public class DecimalValue : AbstractValue<float>
    {
        public DecimalValue(string name, float variable) : base(name, variable) { }
        public override ValueType GetValueType() => ValueType.Decimal;
        public override float ValueConversion(float variable) => variable;
    }
}

