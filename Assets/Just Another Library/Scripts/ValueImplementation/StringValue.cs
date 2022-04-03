using UnityEngine;

namespace JAL.UI
{
    [System.Serializable]
    public class StringValue : AbstractValue<string>
    {
        public StringValue(string name, string variable = "") : base(name, variable) { }
        public override ValueType GetValueType() => ValueType.String;
        public override string ValueConversion(string variable) => variable.Trim();
    }
}

