using UnityEngine;

namespace JAL
{
    [System.Serializable]
    public class StringValue : AbstractValue<string>
    {
        public StringValue(string name, string variable = "") : base(name, variable) { }
        public StringValue(string name, string variable, string Group)
        : base(name, variable, Group) { }

        public StringValue(string name, string variable, string Group, string SubGroup)
        : base(name, variable, Group, SubGroup) { }

        public override ValueType GetValueType() => ValueType.String;
        public override string ValueConversion(string variable) => variable.Trim();
    }
}

