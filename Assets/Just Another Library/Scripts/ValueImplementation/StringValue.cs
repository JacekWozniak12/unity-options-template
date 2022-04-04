using UnityEngine;

namespace JAL
{
    [System.Serializable]
    public class StringValue : AbstractValue<string>
    {
        public StringValue(string name, string variable, System.Action<string> evt, string group = null, string subGroup = null) : base(name, variable, evt, group, subGroup)
        {
        }

        public override ValueType GetValueType() => ValueType.String;
        public override string ValueConversion(string variable) => variable.Trim();
    }
}

