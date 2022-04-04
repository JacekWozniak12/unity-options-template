using JAL.UI;
using UnityEngine;

namespace JAL
{
    [System.Serializable]
    public class SpriteValue : AbstractValue<Sprite>, IImplementOtherValueType
    {
        public SpriteValue(string name, Sprite variable) : base(name, variable) { }
        public SpriteValue(string name, Sprite variable, string Group)
        : base(name, variable, Group) { }

        public SpriteValue(string name, Sprite variable, string Group, string SubGroup)
        : base(name, variable, Group, SubGroup) { }

        public GameObject GetUIImplementation() => SpriteOptionCreator.Instance.Produce(this);
        public override ValueType GetValueType() => ValueType.Other;
        public override Sprite ValueConversion(Sprite variable) => variable;
    }
}

