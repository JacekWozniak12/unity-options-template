using System.Collections.Generic;
using UnityEngine;
using JAL.Extenders;

namespace JAL.UI
{
    public class OptionsView : MonoBehaviour
    {
        public OptionGroup MainGroup;
        public List<OptionGroup> ListOfGroups = new List<OptionGroup>();
        public RectTransform optionList;
        public RectTransform optionGroupButtons;

        private void Awake()
        {
            MainGroup = new GameObject("Main").AddComponent<OptionGroup>();
            MainGroup.transform.SetParent(optionList, false);
            MainGroup.GetComponent<RectTransform>().SetAnchorsStretched();
            MainGroup.Setup(optionGroupButtons, () => SelectGroup(MainGroup));
            gameObject.UI_CreateVerticalLayoutGroup();
            ListOfGroups.Add(MainGroup);
            if(ListOfGroups.Count < 2) optionGroupButtons.gameObject.SetActive(false);
        }

        public void SelectGroup(OptionGroup group = null)
        {
            if(group == null) group = MainGroup;
            foreach(var g in ListOfGroups)
            {
                g.gameObject.SetActive(false);
                group.gameObject.SetActive(true);
            }
        }
    }
}