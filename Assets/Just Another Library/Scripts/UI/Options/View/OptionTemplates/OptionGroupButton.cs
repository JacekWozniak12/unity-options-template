using UnityEngine;
using TDC = TMPro.TMP_DefaultControls;
using TMPro;
using UnityEngine.UI;
using JAL.Extenders;
namespace JAL.UI
{
    public class OptionGroupButton : MonoBehaviour
    {
        public GameObject LabelHolder;
        public GameObject ButtonHolder;
        public Button button;
        public GameObject GroupContainer;

        public string GetGroupName()
            => gameObject.name;

        void Awake()
        {
            Setup();
        }

        public void Setup()
        {
            gameObject.AddComponent<RectTransform>();
            gameObject.AddComponent<HorizontalLayoutGroup>();
            gameObject.UI_CreateLayoutElement();
            SetButtonHolder();
            SetLabelHolder();
        }

        private void SetButtonHolder()
        {
            ButtonHolder = new GameObject("Button");
            ButtonHolder.transform.SetParent(gameObject.transform, false);
            ButtonHolder.AddComponent<RectTransform>();
            button = ButtonHolder.UI_CreateButton();
        }

        private void SetLabelHolder()
        {
            // Set Element Holder
            GameObject elementHolder = new GameObject("Label-Container");
            elementHolder.AddComponent<RectTransform>();
            elementHolder.transform.SetParent(ButtonHolder.transform, false);

            LabelHolder = TDC.CreateText(new TDC.Resources());
            LabelHolder.transform.SetParent(elementHolder.transform, false);
            LabelHolder.name = "Label";

            TextMeshProUGUI tc = LabelHolder.GetComponent<TextMeshProUGUI>();
            tc.color = Color.black;
            tc.alignment = TextAlignmentOptions.Center;
            tc.text = GetGroupName();

            RectTransform rt = LabelHolder.GetComponent<RectTransform>();
            rt.SetAnchorsStretched();
            rt.SetDefault();

            rt = elementHolder.GetComponent<RectTransform>();
            rt.SetAnchorsStretched();
            rt.SetDefault();
        }
    }
}
