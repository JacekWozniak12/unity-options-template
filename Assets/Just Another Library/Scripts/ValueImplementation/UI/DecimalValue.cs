using UnityEngine;

namespace JAL.UI
{
    [System.Serializable]
    public class DecimalValue : AbstractValue<float>
    {
        public DecimalValue(string name, float value, OptionsManager manager) : base(name, value, manager) { }

        public string Name
        {
            get => _name;
            private set => _name = value;
        }

        public float Value
        {
            get => _value;
            set
            {
                if (!value.Equals(_value))
                {
                    //
                }
            }
        }

        public override ValueType GetValueType() => ValueType.Range;
    }
}

