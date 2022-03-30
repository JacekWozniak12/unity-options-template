using UnityEngine;

namespace JAL.UI
{
    [System.Serializable]
    public class StringValue : AbstractValue<string>
    {
        public StringValue(string name, string value, OptionsManager manager) : base(name, value, manager) { }

        public string Name
        {
            get => _name;
            private set => _name = value;
        }

        public string Value
        {
            get => _value;
            set
            {
                if (!value.Equals(_value))
                {
                    _value = value.Trim();
                }
            }
        }

        public override ValueType GetValueType() => ValueType.Range;
    }
}

