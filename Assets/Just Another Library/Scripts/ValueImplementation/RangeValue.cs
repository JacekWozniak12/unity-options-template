using UnityEngine;

namespace JAL
{
    [System.Serializable]
    public class RangeValue : AbstractValue<float>
    {
        public RangeValue(string name, float variable)
        : base(name, variable) { }
        public RangeValue(string name, float variable, string Group)
        : base(name, variable, Group) { }
        public RangeValue(string name, float variable, string Group, string SubGroup)
        : base(name, variable, Group, SubGroup) { }

        public override ValueType GetValueType() => ValueType.Range;
        public override float ValueConversion(float variable) => Mathf.Clamp01(variable);
    }
}

