using UnityEngine;

namespace JAL.UI
{
    [System.Serializable]
    public class RangeValue : AbstractValue<float>
    {
        public RangeValue(string name, float value, OptionsManager manager) : base(name, value, manager) { }

        public string Name
        {
            get => _name;
            set => _name = value;
        }

        [SerializeField]
        public float Value
        {
            get => _value;
            private set
            {
                if (!value.Equals(_value))
                {
                    _value = Mathf.Clamp01(value);
                    //
                }
            }
        }

        public override ValueType GetValueType() => ValueType.Range;
    }
}

