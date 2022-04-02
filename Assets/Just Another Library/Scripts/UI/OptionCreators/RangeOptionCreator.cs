using UnityEngine;
using UnityEngine.UI;
using DC = UnityEngine.UI.DefaultControls;

namespace JAL.UI
{
    public class RangeOptionCreator : AbstractOptionCreator<RangeValue, Slider, float>
    {
        protected override void SetProduct(OptionTemplate option, RangeValue value)
        {
            throw new System.NotImplementedException();
        }

        protected override void VariableComponentSetup(OptionTemplate option)
        {
            throw new System.NotImplementedException();
        }
    }
}
