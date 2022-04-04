using UnityEngine;

namespace JAL
{
    [System.Serializable]
    public class DecimalValue : AbstractValue<float>
    {
        public DecimalValue(string name, float variable, System.Action<float> evt, string group = null, string subGroup = null) : base(name, variable, evt, group, subGroup)
        {
        }

        public override ValueType GetValueType() => ValueType.Decimal;
        public override float ValueConversion(float variable) => variable;
    }
}

