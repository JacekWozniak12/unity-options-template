using UnityEngine;
using TDC = TMPro.TMP_DefaultControls;
using TMPro;
using UnityEngine.UI;
using JAL.Extenders;
namespace JAL.UI
{
    public class OptionGroupHeader : MonoBehaviour
    {
        public GameObject LabelHolder;
        public GameObject GroupContainer;

        public void Setup()
        {
            gameObject.AddComponent<RectTransform>();
            gameObject.AddComponent<HorizontalLayoutGroup>();
            gameObject.UI_CreateLayoutElement(minHeight: 75);
            SetLabelHolder();
        }

        private void SetLabelHolder()
        {
            // Set Element Holder
            GameObject elementHolder = new GameObject("Label-Container");
            elementHolder.transform.SetParent(transform, false);
            gameObject.UI_CreateLayoutElement(flexibleWidth: 75);

            LabelHolder = TDC.CreateText(new TDC.Resources());
            LabelHolder.transform.SetParent(elementHolder.transform, false);
            LabelHolder.name = "Label";
            TextMeshProUGUI tc = LabelHolder.GetComponent<TextMeshProUGUI>();
            tc.color = Color.black;
            tc.alignment = TextAlignmentOptions.Center;

            RectTransform rt = LabelHolder.GetComponent<RectTransform>();
            rt.SetAnchorsStretched();
            rt.SetDefault();
        }
    }
}
