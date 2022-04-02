using System.Reflection.Emit;
using UnityEngine;
using TDC = TMPro.TMP_DefaultControls;
using TMPro;
using UnityEngine.UI;
namespace JAL.UI
{
    public class OptionTemplate : MonoBehaviour
    {
        public GameObject LabelHolder;
        public GameObject VariableHolder;

        public Component VariableComponent
        {
            get;
            private set;
        }

        public Component AddVariableComponent<T1>() where T1 : Component
        {
            VariableHolder = new GameObject();
            SetVariableHolder();
            VariableComponent = VariableHolder.AddComponent<T1>();
            return VariableComponent;
        }

        public Component AddVariableComponent<T1>(GameObject resultOfCreator) where T1 : Component
        {
            VariableHolder = resultOfCreator;
            SetVariableHolder();

            VariableComponent = resultOfCreator.GetComponentInChildren<T1>();

            if (VariableComponent == null)
            {
                Debug.LogWarning("Object does not have specified component type. Change creator", resultOfCreator);
            }

            return VariableComponent;
        }

        public void Setup()
        {
            gameObject.AddComponent<RectTransform>();
            gameObject.AddComponent<HorizontalLayoutGroup>();
            SetLabelHolder();
        }

        private void SetLabelHolder()
        {
            LabelHolder = TDC.CreateText(new TDC.Resources());
            LabelHolder.transform.SetParent(transform, false);
            LabelHolder.name = "Label";
            LabelHolder.GetComponent<TextMeshProUGUI>().color = Color.black;
            LabelHolder.AddComponent<LayoutElement>();
        }

        private void SetVariableHolder()
        {
            VariableHolder.name = "Value";
            VariableHolder.transform.SetParent(this.transform, false);
            VariableHolder.AddComponent<LayoutElement>();
        }
    }
}
