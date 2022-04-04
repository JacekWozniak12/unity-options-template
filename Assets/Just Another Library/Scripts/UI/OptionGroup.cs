using System.Collections.Generic;
using UnityEngine;

namespace JAL.UI
{
    public class OptionGroup : MonoBehaviour, IValueGroup
    {
        public OptionSubGroup Main;
        public List<OptionSubGroup> SubGroups = new List<OptionSubGroup>();
        public IValueSubGroup Default => Main;
        public string GetGroupName() => $"{gameObject.name}";
        
        OptionGroupButton buttonHolder;

        private void Awake()
        {
            Main = new GameObject("main").AddComponent<OptionSubGroup>();
            
        }

        public void Setup(RectTransform buttonGroup)
        {
            buttonHolder = new GameObject($"{gameObject.name} - Button").AddComponent<OptionGroupButton>();
        }
    }
}