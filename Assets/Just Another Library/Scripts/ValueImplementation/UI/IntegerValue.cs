using System;
using UnityEngine;

namespace JAL.UI
{
    [System.Serializable]
    public class IntegerValue : AbstractValue<int>
    {
        public IntegerValue(string name, int value, OptionsManager manager) : base(name, value, manager) { }

        public string Name
        {
            get => _name;
            private set => _name = value;
        }

        public int Value
        {
            get => _value;
            set
            {
                if (!value.Equals(_value))
                {
                    value = _value;
                    
                }
            }
        }

        public override sealed ValueType GetValueType() => ValueType.Integer;
    }
}

