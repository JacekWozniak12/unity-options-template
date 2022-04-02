using UnityEngine;
using TMPro;
using DC = TMPro.TMP_DefaultControls;

namespace JAL.UI
{
    public class StringOptionCreator : AbstractOptionCreator<StringValue, TMP_InputField, string>
    {
        protected override void SetProduct(OptionTemplate option, StringValue value)
        {
            throw new System.NotImplementedException();
        }

        protected override void VariableComponentSetup(OptionTemplate option)
        {
            throw new System.NotImplementedException();
        }
    }
}
