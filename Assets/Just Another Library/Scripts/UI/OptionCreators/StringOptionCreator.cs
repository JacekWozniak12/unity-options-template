using UnityEngine;
using TMPro;
using DC = TMPro.TMP_DefaultControls;

namespace JAL.UI
{
    public class StringOptionCreator : AbstractOptionCreator<StringValue, TMP_InputField>
    {
        public override GameObject Produce(StringValue value)
        {
            GameObject option = Instantiate(template, transform);
            option.name = value.Name;
            return option;
        }

        protected override GameObject CreateTemplate() => DC.CreateInputField(new DC.Resources());
    }
}
