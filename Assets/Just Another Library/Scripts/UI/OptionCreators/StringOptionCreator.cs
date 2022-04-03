using UnityEngine;
using TMPro;
using TDC = TMPro.TMP_DefaultControls;

namespace JAL.UI
{
    public class StringOptionCreator : AbstractOptionCreator<StringValue, TMP_InputField, string>
    {
        protected override void SetProduct(OptionTemplate option, StringValue value)
        {
            TMP_InputField T1 = (TMP_InputField)option.VariableComponent;
            T1.text = value.Variable;
            T1.onValueChanged.AddListener((string x) => value.Variable = x);
        }

        protected override void SetVariableComponent(OptionTemplate option)
        {
            var c = option.AddVariableComponent<TMP_InputField>(TDC.CreateInputField(new TDC.Resources()));
        }
    }
}
