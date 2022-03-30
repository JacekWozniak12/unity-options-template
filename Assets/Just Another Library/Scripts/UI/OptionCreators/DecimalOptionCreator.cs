using UnityEngine;
using TMPro;
using TDC = TMPro.TMP_DefaultControls;

namespace JAL.UI
{
    public class DecimalOptionCreator : AbstractOptionCreator<DecimalValue, TMP_InputField>
    {
        protected override OptionTemplate CreateTemplate()
        {
            // Create GameObjects
            GameObject group = new GameObject(typeof(DecimalOptionCreator).ToString());
            OptionTemplate template = group.AddComponent<OptionTemplate>();
            GameObject labelHolder = TDC.CreateText(new TDC.Resources());
            GameObject variableHolder = TDC.CreateInputField(new TDC.Resources());
            
            // Set transforms
            labelHolder.transform.SetParent(group.transform, false);
            variableHolder.transform.SetParent(group.transform, false);

            // Set names and features
            labelHolder.name = "Label";
            variableHolder.name = "Value";
            variableHolder.GetComponent<TMP_InputField>().contentType = TMP_InputField.ContentType.DecimalNumber;

            // Set references
            template.LabelHolder = labelHolder;
            template.VariableHolder = variableHolder;

            return template;
        }

        public override GameObject Produce(DecimalValue value)
        {
            OptionTemplate option = Instantiate(template, transform);
            option.gameObject.name = $"Object - {value.Name}";
            option.gameObject.SetActive(true);

            option.LabelHolder.GetComponent<TextMeshProUGUI>().text = value.Name;
            option.VariableHolder.GetComponent<TMP_InputField>().text = value.Variable.ToString();
            return option.gameObject;
        }
    }
}
