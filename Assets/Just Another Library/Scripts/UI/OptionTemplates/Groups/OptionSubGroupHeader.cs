using System.Reflection.Emit;
using UnityEngine;
using TDC = TMPro.TMP_DefaultControls;
using TMPro;
using UnityEngine.UI;
namespace JAL.UI
{
    public class OptionSubGroupHeader : MonoBehaviour
    {
        public GameObject LabelHolder;

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
            tc.alignment = TextAlignmentOptions.Center;

            RectTransform rt = LabelHolder.GetComponent<RectTransform>();
            rt.anchorMin = Vector2.zero;
            rt.anchorMax = Vector2.one;
            rt.sizeDelta = Vector2.zero;
            rt.offsetMin = Vector2.left;
        }
    }
}
