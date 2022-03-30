using UnityEngine;
using UnityEngine.UI;
using DC = UnityEngine.UI.DefaultControls;

namespace JAL.UI
{
    public class RangeOptionCreator : AbstractOptionCreator<RangeValue, Slider>
    {
        public override GameObject Produce(RangeValue value)
        {
            throw new System.NotImplementedException();
        }

        protected override OptionTemplate CreateTemplate()
        {
            throw new System.NotImplementedException();
        }
    }
}
