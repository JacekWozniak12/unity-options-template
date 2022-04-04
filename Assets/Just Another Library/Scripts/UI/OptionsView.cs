using System.Collections.Generic;
using UnityEngine;
using JAL.Extenders;

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
            MainGroup = new GameObject("Main").AddComponent<OptionGroup>();
            MainGroup.transform.SetParent(optionList, false);
            MainGroup.GetComponent<RectTransform>().SetAnchorsStretched();
            MainGroup.Setup(optionGroupButtons);
            gameObject.UI_CreateVerticalLayoutGroup();
        }
    }
}