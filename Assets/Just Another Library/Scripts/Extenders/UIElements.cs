using UnityEngine;
using UnityEngine.UI;

namespace JAL.Extenders
{
    public static class UIElements
    {
        /// <summary>
        /// Creates layout element and sets the corresponding
        /// size values to the members if
        /// those values does not equal 0
        /// </summary>
        /// <returns>Created LayoutElement on GameObject</returns>
        public static LayoutElement UI_CreateLayoutElement(
            this GameObject gameObject,
            int priority = 1,
            float minHeight = 0,
            float minWidth = 0,
            float flexibleWidth = 0,
            float flexibleHeight = 0,
            float preferredWidth = 0,
            float preferredHeight = 0,
            bool useGUILayout = false
            )
        {
            var le = gameObject.AddComponent<LayoutElement>();
            le.layoutPriority = priority;
            le.useGUILayout = useGUILayout;

            if (minHeight != 0) le.minHeight = minHeight;
            if (minWidth != 0) le.minWidth = minWidth;
            if (flexibleHeight != 0) le.flexibleHeight = flexibleHeight;
            if (flexibleWidth != 0) le.flexibleWidth = flexibleWidth;
            if (preferredHeight != 0) le.preferredHeight = preferredHeight;
            if (preferredWidth != 0) le.preferredWidth = preferredWidth;

            return le;
        }

        /// <returns>Created ContentSizeFitter on GameObject</returns>
        public static ContentSizeFitter UI_CreateContentSizeFitter(
            this GameObject gameObject,
            ContentSizeFitter.FitMode verticalFit = ContentSizeFitter.FitMode.Unconstrained,
            ContentSizeFitter.FitMode horizontalFit = ContentSizeFitter.FitMode.Unconstrained
        )
        {
            var csf = gameObject.AddComponent<ContentSizeFitter>();
            csf.verticalFit = verticalFit;
            csf.horizontalFit = horizontalFit;
            return csf;
        }

        public static HorizontalLayoutGroup UI_CreateHorizontalLayoutGroup(
            this GameObject gameObject,
            TextAnchor childAlignment = TextAnchor.UpperLeft,
            bool reverseArrangement = false,
            bool childControlHeight = false,
            bool childControlWidth = false,
            bool childForceExpandHeight = true,
            bool childForceExpandWidth = true,
            bool childScaleHeight = false,
            bool childScaleWidth = false
        )
        {
            var hlg = gameObject.AddComponent<HorizontalLayoutGroup>();
            hlg.childAlignment = childAlignment;
            hlg.reverseArrangement = reverseArrangement;

            hlg.childControlHeight = childControlHeight;
            hlg.childControlWidth = childControlWidth;
            hlg.childForceExpandHeight = childForceExpandHeight;
            hlg.childForceExpandWidth = childForceExpandWidth;
            hlg.childScaleHeight = childScaleHeight;
            hlg.childScaleWidth = childScaleWidth;

            return hlg;
        }

        public static VerticalLayoutGroup UI_CreateVerticalLayoutGroup(
            this GameObject gameObject,
            TextAnchor childAlignment,
            bool reverseArrangement = false,
            bool childControlHeight = false,
            bool childControlWidth = false,
            bool childForceExpandHeight = true,
            bool childForceExpandWidth = true,
            bool childScaleHeight = false,
            bool childScaleWidth = false
        )
        {
            var vlg = gameObject.AddComponent<VerticalLayoutGroup>();
            vlg.childAlignment = childAlignment;
            vlg.reverseArrangement = reverseArrangement;

            vlg.childControlHeight = childControlHeight;
            vlg.childControlWidth = childControlWidth;
            vlg.childForceExpandHeight = childForceExpandHeight;
            vlg.childForceExpandWidth = childForceExpandWidth;
            vlg.childScaleHeight = childScaleHeight;
            vlg.childScaleWidth = childScaleWidth;

            return vlg;
        }
    }
}