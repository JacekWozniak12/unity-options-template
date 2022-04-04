using System.Reflection.Emit;
using UnityEngine;
using TDC = TMPro.TMP_DefaultControls;
using TMPro;
using UnityEngine.UI;
namespace JAL.UI
{
    public class OptionItem : MonoBehaviour
    {
        public GameObject LabelHolder;
        public GameObject VariableHolder;

        public Component VariableComponent
        {
            get;
            private set;
        }

        public T1 AddVariableComponent<T1>() where T1 : Component
        {
            VariableHolder = new GameObject();
            SetVariableHolder();
            VariableComponent = VariableHolder.AddComponent<T1>();
            return VariableComponent as T1;
        }

        public T1 AddVariableComponent<T1>(GameObject resultOfCreator) where T1 : Component
        {
            VariableHolder = resultOfCreator;
            SetVariableHolder();
            VariableComponent = resultOfCreator.GetComponentInChildren<T1>();

            if (VariableComponent == null)
                Debug.LogWarning("Object does not have specified component type. Change creator", resultOfCreator);

            return VariableComponent as T1;
        }

        public void Setup()
        {
            gameObject.AddComponent<RectTransform>();
            gameObject.AddComponent<HorizontalLayoutGroup>();
            LayoutElement le = gameObject.AddComponent<LayoutElement>();
            le.minHeight = 75;
            SetLabelHolder();
        }

        private void SetLabelHolder()
        {
            // Set Element Holder
            GameObject elementHolder = new GameObject("Label-Container");
            elementHolder.transform.SetParent(transform, false);
            LayoutElement layoutElement = elementHolder.AddComponent<LayoutElement>();
            layoutElement.flexibleWidth = 1;

            LabelHolder = TDC.CreateText(new TDC.Resources());
            LabelHolder.transform.SetParent(elementHolder.transform, false);
            LabelHolder.name = "Label";
            TextMeshProUGUI tc = LabelHolder.GetComponent<TextMeshProUGUI>();
            tc.color = Color.black;
            tc.alignment = TextAlignmentOptions.Left;

            RectTransform rt = LabelHolder.GetComponent<RectTransform>();
            rt.anchorMin = Vector2.zero;
            rt.anchorMax = Vector2.one;
            rt.sizeDelta = Vector2.zero;
            rt.offsetMin = Vector2.left;
        }

        private void SetVariableHolder()
        {
            // Set Element Holder
            GameObject elementHolder = new GameObject("Value-Container");
            elementHolder.transform.SetParent(transform, false);
            LayoutElement layoutElement = elementHolder.AddComponent<LayoutElement>();
            layoutElement.flexibleWidth = 2;

            // Set Holder
            VariableHolder.name = "Value";
            VariableHolder.transform.SetParent(elementHolder.transform, false);
            
            RectTransform rt = VariableHolder.GetComponent<RectTransform>();
            rt.anchorMin = Vector2.zero;
            rt.anchorMax = Vector2.one;
            rt.sizeDelta = Vector2.zero;
        }
    }
}
