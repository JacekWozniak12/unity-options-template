using UnityEngine;
using TMPro;
using DC = TMPro.TMP_DefaultControls;

namespace JAL.UI
{
    public class IntegerOptionCreator : AbstractOptionCreator<IntegerValue, TMP_InputField>
    {
        protected override GameObject CreateTemplate()
        {
            GameObject template = DC.CreateInputField(new DC.Resources());
            template.GetComponent<TMP_InputField>().contentType = TMP_InputField.ContentType.IntegerNumber;
            return template;
        }

        public override GameObject Produce(IntegerValue value)
        {
            GameObject option = Instantiate(template, transform);
            option.name = value.Name;
            return option;
        }
    }
}
