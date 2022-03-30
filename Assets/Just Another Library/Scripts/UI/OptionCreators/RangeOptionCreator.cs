using UnityEngine;
using UnityEngine.UI;
using DC = UnityEngine.UI.DefaultControls;

namespace JAL.UI
{
    public class RangeOptionCreator : AbstractOptionCreator<RangeValue, Slider>
    {
        public override GameObject Produce(RangeValue value)
        {
            GameObject option = Instantiate(template, transform);
            option.name = value.Name;
            return option;
        }

        protected override GameObject CreateTemplate() => DC.CreateSlider(new DC.Resources());
    }
}
