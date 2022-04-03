using UnityEngine;
using UnityEngine.UI;

namespace JAL
{
    [CreateAssetMenu(fileName = "UI_Style_File", menuName = "unity-options-template/UI_Style", order = 0)]
    public class UIStyleOption : ScriptableObject
    {
        [Header("Size")]
        public int FontSize;
        public int Margin;

        [Header("Colors")]
        public Color FontColor;
        public Color Background;
        public Color Main;
    }
}