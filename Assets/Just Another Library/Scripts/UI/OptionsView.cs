using System.Collections.Generic;
using UnityEngine;

namespace JAL.UI
{
    public class OptionsView : MonoBehaviour
    {
        public List<OptionGroup> Groups = new List<OptionGroup>();
        public RectTransform optionList;
        public RectTransform optionGroupButtons;
    }
}