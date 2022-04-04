using JAL.Extenders;
using UnityEngine;
using UnityEngine.UI;
using DC = UnityEngine.UI.DefaultControls;

namespace JAL.UI
{
    public class RangeOptionCreator : AbstractOptionCreator<RangeValue, Slider, float>
    {
        protected override void SetProduct(OptionItem option, RangeValue value)
        {
            Slider T1 = (Slider)option.VariableComponent;
            T1.value = value.Variable;
            T1.onValueChanged.AddListener((float x) => value.Variable = x);
        }

        protected override void SetVariableComponent(OptionItem option)
        {
            var c = option.AddVariableComponent<Slider>(DC.CreateSlider(new DC.Resources()));
            
            c.fillRect.SetAnchorsStretched();
            c.transform.Find("Fill Area").GetComponent<RectTransform>().SetAnchorsStretched();
            c.transform.Find("Handle Slide Area").GetComponent<RectTransform>().SetAnchorsStretched();
            c.transform.Find("Background").GetComponent<RectTransform>().SetAnchorsStretched();

            c.fillRect.GetComponent<Image>().color = Color.red;
            c.handleRect.GetComponent<Image>().color = Color.red;
        }
    }
}
