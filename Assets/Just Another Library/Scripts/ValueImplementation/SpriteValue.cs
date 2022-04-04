using JAL.UI;
using UnityEngine;

namespace JAL
{
    [System.Serializable]
    public class SpriteValue : AbstractValue<Sprite>, IImplementOtherValueType
    {
        public SpriteValue(string name, Sprite variable, System.Action<Sprite>[] events = null, string group = null, string subGroup = null) 
        : base(name, variable, events, group, subGroup)
        {
        }

        public GameObject GetUIImplementation() => SpriteOptionCreator.Instance.Produce(this);
        public override ValueType GetValueType() => ValueType.Other;
        public override Sprite ValueConversion(Sprite variable) => variable;
    }
}

