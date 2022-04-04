using UnityEngine;

namespace JAL
{
    [CreateAssetMenu(fileName = "UI_Style_File", menuName = "unity-options-template/UI_Style", order = 0)]
    public class UIStyleContainer : ScriptableObject
    {
        [Header("Size")]
        public int FontSize;
        public int Margin;

        [Header("Colors")]
        public Color Background = Color.black;
        public Color Item_Background = Color.black;
        public Color FontColor = Color.black;
        public Color Primary = Color.black;
        public Color Secondary = Color.black;

        [Header("Sounds")]
        public AudioClip Click;
        public AudioClip Save;
    }
}