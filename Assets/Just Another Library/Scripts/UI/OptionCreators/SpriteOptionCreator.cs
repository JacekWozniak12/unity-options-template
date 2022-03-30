using UnityEngine;
using UnityEngine.UI;

namespace JAL.UI
{
    public class SpriteOptionCreator : AbstractOptionCreator<SpriteValue, Image>
    {
        public override GameObject CreateUIRepresentationOfValue(SpriteValue value)
        {
            GameObject option = Instantiate(template, transform);
            option.name = value.Name;
            return option;
        }

        protected override GameObject CreateTemplate()
        {
            GameObject gameObject = new GameObject(typeof(SpriteValue).ToString());
            gameObject.AddComponent<Image>();
            return gameObject;
        }
    }
}
