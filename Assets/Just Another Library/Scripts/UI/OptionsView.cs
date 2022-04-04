using System.Collections.Generic;
using UnityEngine;

namespace JAL.UI
{
    public class OptionsView : MonoBehaviour
    {
        public OptionGroup MainGroup;
        public List<OptionGroup> Groups = new List<OptionGroup>();
        public RectTransform optionList;
        public RectTransform optionGroupButtons;

        private void Awake()
        {
            MainGroup = new GameObject("main").AddComponent<OptionGroup>();
        }
    }
}