using System.Collections.Generic;
using UnityEngine;

namespace JAL.UI
{
    public class OptionGroup : MonoBehaviour, IValueGroup
    {
        public List<OptionSubGroup> SubGroups = new List<OptionSubGroup>();
        public OptionSubGroup Main;

        OptionGroupButton buttonHolder; 

        private void Awake()
        {
            Main = new GameObject("main").AddComponent<OptionSubGroup>();
        }

        public string GetName() => $"{gameObject.name}";

        public void Setup(RectTransform buttonGroup)
        {
            buttonHolder = new GameObject($"{gameObject.name} - Button").AddComponent<OptionGroupButton>();
        }
    }
}