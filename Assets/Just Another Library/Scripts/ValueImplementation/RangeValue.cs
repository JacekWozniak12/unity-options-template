using UnityEngine;

namespace JAL
{
    [System.Serializable]
    public class RangeValue : AbstractValue<float>
    {
        public RangeValue(float variable,
                          string name = null,
                          System.Action<float>[] events = null,
                          string group = null,
                          string subGroup = null) : base(variable, name, events, group, subGroup)
        {
        }

        public override ValueType GetValueType() => ValueType.Range;
        public override float ValueConversion(float variable) => Mathf.Clamp01(variable);
    }
}

