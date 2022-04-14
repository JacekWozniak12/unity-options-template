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

        // Data
        GameObject previous;

        List<Tuple<MonoBehaviour, FieldInfo>> previousAttributes
            = new List<Tuple<MonoBehaviour, FieldInfo>>();

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
                previousAttributes.Clear();
                CollectDataFromMonoBehaviours(previous);
            }

            HandleTooltip(
                CollectDataFromAttributes(previousAttributes.ToArray())
                );
        }

        private void HandleTooltip(string content)
        {
            if (content.Length == 0)
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

        private void CollectDataFromMonoBehaviours(GameObject gameObject)
        {
            MonoBehaviour[] components = previous.GetComponents<MonoBehaviour>();

            foreach (MonoBehaviour cp in components)
            {
                CollectAttributesFromMonoBehaviours(cp);
            }
        }

        private void CollectAttributesFromMonoBehaviours(MonoBehaviour monoBehaviour)
        {
            var fields = monoBehaviour.GetType().
                GetFields(
                    BindingFlags.NonPublic |
                    BindingFlags.Public |
                    BindingFlags.Instance
                    );

            foreach (FieldInfo f in fields)
            {
                var attr = f.GetCustomAttribute<UI_TooltipAttribute>();
                if (attr != null)
                {
                    previousAttributes.Add(
                        new Tuple<MonoBehaviour, FieldInfo>(monoBehaviour, f)
                        );
                }
            }
        }

        private string CollectDataFromAttributes(Tuple<MonoBehaviour, FieldInfo>[] tuples)
        {
            string content = "";

            foreach (var t in tuples)
            {
                FieldInfo f = t.Item2;

                UI_TooltipAttribute attr = f.GetCustomAttribute<UI_TooltipAttribute>();

                string value;
                if (attr.Field.Length > 0)
                {
                    var searchedField = f.GetValue(t.Item1);

                    value = searchedField
                        .GetType().GetField(attr.Field,
                            BindingFlags.NonPublic |
                            BindingFlags.Public |
                            BindingFlags.Instance
                            )
                        .GetValue(searchedField)
                        .ToString();
                }
                else value = f.GetValue(t.Item1).ToString();

                content += $"\n{attr.Name}: {value}";
            }

            return content;
        }
    }
}
