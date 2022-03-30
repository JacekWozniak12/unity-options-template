using UnityEngine;

namespace JAL.UI
{
    [System.Serializable]
    public class RangeValue : AbstractValue<float>
    {
        public RangeValue(string name, float variable) : base(name, variable) { }
        public override ValueType GetValueType() => ValueType.Range;
        public override float ValueConversion(float variable) => Mathf.Clamp01(variable);
    }
}
