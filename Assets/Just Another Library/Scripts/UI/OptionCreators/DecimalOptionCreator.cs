using UnityEngine;
using TMPro;
using TDC = TMPro.TMP_DefaultControls;

namespace JAL.UI
{
    public class DecimalOptionCreator : AbstractOptionCreator<DecimalValue, TMP_InputField>
    {
        protected override GameObject CreateTemplate()
        {
            GameObject labelHolder = TDC.CreateText(new TDC.Resources());
            labelHolder.name = "Label";

            GameObject valueHolder = TDC.CreateInputField(new TDC.Resources());
            valueHolder.name = "Value";
            valueHolder.GetComponent<TMP_InputField>().contentType = TMP_InputField.ContentType.DecimalNumber;
            return valueHolder;
        }

        public override GameObject Produce(DecimalValue value)
        {
            GameObject option = Instantiate(template, transform);
            option.name = $"Object - {value.Name}";

            GameObject labelHolder = option.transform.Find("Label").gameObject;
            GameObject valueHolder = option.transform.Find("Value").gameObject;

            labelHolder.GetComponent<TMP_InputField>().text = value.Name;
            valueHolder.GetComponent<TMP_InputField>().text = value.Variable.ToString();

            return option;
        }
    }
}
