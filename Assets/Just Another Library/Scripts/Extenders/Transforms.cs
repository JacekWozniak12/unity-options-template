using UnityEngine;

namespace JAL.Extenders
{
    public static class Transforms
    {
        public static RectTransform SetAnchors(
            this RectTransform rt, Vector2 min, Vector2 max)
        {
            rt.anchorMin = min;
            rt.anchorMax = max;
            return rt;
        }

        public static RectTransform SetAnchorsStretched(
            this RectTransform rt) => 
            SetAnchors(rt, Vector2.zero, Vector2.one);

        public static RectTransform SetDefault(
            this RectTransform rt)
        {
            rt.sizeDelta = Vector2.zero;
            rt.offsetMin = Vector2.left;
            return rt;
        }

        public static RectTransform SetPivots(
            this RectTransform rt, Vector2 pivot)
        {
            rt.pivot = pivot;
            return rt;
        }
    }
}