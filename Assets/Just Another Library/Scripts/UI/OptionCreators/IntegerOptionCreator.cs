using TMPro;
using TDC = TMPro.TMP_DefaultControls;

namespace JAL.UI
{
    public class IntegerOptionCreator : AbstractOptionCreator<IntegerValue, TMP_InputField, int>
    {
        protected override void SetProduct(OptionItem option, IntegerValue value)
        {
            TMP_InputField T1 = (TMP_InputField) option.VariableComponent;
            T1.text = value.Variable.ToString();
            T1.onEndEdit.AddListener((string x) => value.Variable = int.Parse(x));
        }

        protected override void SetVariableComponent(OptionItem option)
        {
            var c = option.AddVariableComponent<TMP_InputField>(TDC.CreateInputField(new TDC.Resources()));
            c.contentType = TMP_InputField.ContentType.IntegerNumber;
        }
    }
}
