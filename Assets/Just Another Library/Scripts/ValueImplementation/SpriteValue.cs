using UnityEngine;

namespace JAL.UI
{
    [System.Serializable]
    public class SpriteValue : AbstractValue<Sprite>, IImplementUIOfOtherValueType
    {
        public SpriteValue(string name, Sprite variable) : base(name, variable){}
        public GameObject GetUIImplementation() => SpriteOptionCreator.Instance.Produce(this);
        public override ValueType GetValueType() => ValueType.Other;
        public override Sprite ValueConversion(Sprite variable) => variable;
    }
}

