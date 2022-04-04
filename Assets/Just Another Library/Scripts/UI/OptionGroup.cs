using System.Collections.Generic;
using JAL.Extenders;
using UnityEngine;
using UnityEngine.Events;

namespace JAL.UI
{
    public class OptionGroup : MonoBehaviour, IValueGroup
    {
        public List<OptionSubGroup> SubGroups = new List<OptionSubGroup>();
        public OptionSubGroup Main;

        OptionGroupButton buttonHolder;

        private void Awake()
        {
            Main = new GameObject("Default").AddComponent<OptionSubGroup>();
            gameObject.AddComponent<RectTransform>();
            Main.transform.SetParent(transform, false);
            gameObject.UI_CreateLayoutElement();
            SetLayoutGroup();
        }

        public void SetLayoutGroup()
        {
            gameObject.UI_CreateVerticalLayoutGroup(
                childControlWidth: true, 
                childControlHeight: true
                );
        }

        public string GetName() => $"{gameObject.name}";

        public void Setup(RectTransform buttonGroup, UnityAction action)
        {
            buttonHolder = new GameObject($"{gameObject.name} - Button").AddComponent<OptionGroupButton>();
            buttonHolder.transform.SetParent(buttonGroup, false);
            buttonHolder.button.onClick.AddListener(action);
        }
    }
}