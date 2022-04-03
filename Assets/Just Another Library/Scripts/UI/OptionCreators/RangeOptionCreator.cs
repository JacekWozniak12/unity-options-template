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
            c.fillRect.anchorMin = Vector2.zero;
            c.fillRect.anchorMax = Vector2.one;

            // Boiler plate for range
            
            // Fill
            RectTransform rt;
            
            rt = c.transform.Find("Fill Area").GetComponent<RectTransform>();
            rt.anchorMin = Vector2.zero;
            rt.anchorMax = Vector2.one;
            
            // Handle
            rt = c.transform.Find("Handle Slide Area").GetComponent<RectTransform>();
            rt.anchorMin = Vector2.zero;
            rt.anchorMax = Vector2.one;

            // Background
            rt = c.transform.Find("Background").GetComponent<RectTransform>();
            rt.anchorMin = Vector2.zero;
            rt.anchorMax = Vector2.one;

            // Colors
            c.fillRect.GetComponent<Image>().color = Color.red;
            c.handleRect.GetComponent<Image>().color = Color.red;
        }
    }
}
