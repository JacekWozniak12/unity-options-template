using UnityEngine;
using TMPro;
using TDC = TMPro.TMP_DefaultControls;

namespace JAL.UI
{
    public class DecimalOptionCreator :
    AbstractOptionCreator<DecimalValue, TMP_InputField, float>
    {
        protected override void SetProduct(OptionTemplate option, DecimalValue value)
        {
            TMP_InputField T1 = (TMP_InputField) option.VariableComponent;
            T1.text = value.Variable.ToString();
            T1.onEndEdit.AddListener((string x) => value.Variable = float.Parse(x));
        }

        protected override void VariableComponentSetup(OptionTemplate option)
        {
            option.AddVariableComponent<TMP_InputField>(TDC.CreateInputField(new TDC.Resources()));
        }
    }
}
