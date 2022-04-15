using UnityEngine;
using System.Reflection;
using System.Collections.Generic;
using System;

namespace JAL
{
    public class UI_TooltipDisplayer : MonoBehaviourSingleton<UI_TooltipDisplayer>
    {
        // Display settings
        [SerializeField]
        GameObject tooltipGameObject;

        [SerializeField]
        TMPro.TextMeshProUGUI tooltipTextComponent;

        GameObject previous;

        private void Start()
        {
            GameObject.Find("Hover3DScene")
                .GetComponent<Hover3DScene>().hoverOnSceneEvent
                .AddListener((x) => HandleGameObject(x));

            GameObject.Find("HoverUIScene")
                .GetComponent<HoverUIScene>().hoverOnSceneEvent
                .AddListener((x) => HandleGameObject(x));
        }

        public void HandleGameObject(GameObject temp)
        {
            if (temp == null)
            {
                HandleTooltip("");
                previous = temp;
                return;
            }
            if (previous == null || previous != temp)
            {
                previous = temp;
                string v = previous?.GetComponent<UI_GetTooltip>()?.Tooltip;
                HandleTooltip(v);
            }
        }

        private void HandleTooltip(string content)
        {
            if (content == null || content.Length == 0)
                tooltipGameObject.SetActive(false);
            else
            {
                if (tooltipGameObject.activeSelf != true)
                {
                    var rt = tooltipGameObject.GetComponent<RectTransform>();
                    rt.position = Input.mousePosition;
                    tooltipGameObject.SetActive(true);
                }
                tooltipTextComponent.text = content;
            }
        }
    }
}
