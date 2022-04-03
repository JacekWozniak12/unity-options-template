using UnityEngine;
using UnityEngine.UI;
using DC = UnityEngine.UI.DefaultControls;

namespace JAL.UI
{
    public class RangeOptionCreator : AbstractOptionCreator<RangeValue, Slider, float>
    {
        protected override void SetProduct(OptionTemplate option, RangeValue value)
        {
            Slider T1 = (Slider)option.VariableComponent;
            T1.value = value.Variable;
            T1.onValueChanged.AddListener((float x) => value.Variable = x);
        }

        protected override void SetVariableComponent(OptionTemplate option)
        {
            var c = option.AddVariableComponent<Slider>(DC.CreateSlider(new DC.Resources()));
        }
    }
}
