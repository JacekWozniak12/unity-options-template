using UnityEngine;

namespace JAL.UI
{
    [System.Serializable]
    public class SpriteValue : AbstractValue<Sprite>, IImplementUIOfOtherValueType
    {
        public SpriteValue(string name, Sprite value, OptionsManager manager) : base(name, value, manager)
        {
        }

        public string Name
        {
            get => _name;
            private set => _name = value;
        }

        public Sprite Value
        {
            get => _value;
            set
            {
                if (!value.Equals(_value))
                {
                }
            }
        }
        
        public GameObject GetUIImplementation() => SpriteOptionCreator.Instance.CreateUIRepresentationOfValue(this);
        public override ValueType GetValueType() => ValueType.Other;
    }
}

