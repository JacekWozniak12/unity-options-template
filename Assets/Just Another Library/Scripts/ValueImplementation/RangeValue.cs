using UnityEngine;

namespace JAL
{
    [System.Serializable]
    public class RangeValue : AbstractValue<float>
    {
        public RangeValue(string name, float variable, System.Action<float> evt, string group = null, string subGroup = null) : base(name, variable, evt, group, subGroup)
        {
        }

        public override ValueType GetValueType() => ValueType.Range;
        public override float ValueConversion(float variable) => Mathf.Clamp01(variable);
    }
}

