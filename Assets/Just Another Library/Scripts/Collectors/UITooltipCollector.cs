using UnityEngine.SceneManagement;
using UnityEngine;

using System.Collections.Generic;
using System.Reflection;
using System.Linq;
namespace JAL
{
    /// <summary>
    /// Handles the subscription via ValueClassSubscriberAttribute
    /// </summary>
    public class UITooltipCollector : MonoBehaviourSingleton<UITooltipCollector>, ISceneLoadSubscriber, ICollect
    {
        [SerializeField]
        private List<UITooltipCollector> Collection = new List<UITooltipCollector>();

        public void OnLoadAction(Scene[] scenes) => CollectFrom(scenes);

        public void CollectFrom(Scene[] scenes)
        {
            List<GameObject> temp = new List<GameObject>();

            foreach (Scene scene in scenes)
            {
                var objects = SceneGameObjectCollector.Instance.GetGameObjectsFromScene(scene);
                temp.AddRange(objects);
            }

            CollectAbstractValues(temp.ToArray());
        }

        private void CollectAbstractValues(GameObject[] gameObjects)
        {
            foreach (GameObject gameObject in gameObjects)
            {
                // Attribute section
                var components = gameObject.GetComponentsInChildren<ITooltipAttributeImplementator>();
                foreach (var childrenComponent in components)
                {
                    var type = childrenComponent.GetType();
                    UI_GetTooltip uiTooltipComponent = null;

                    if (childrenComponent is Component c)
                    {
                        uiTooltipComponent = c.GetComponent<UI_GetTooltip>();

                        if (uiTooltipComponent == null)
                            uiTooltipComponent = c.gameObject.AddComponent<UI_GetTooltip>();
                    }
                    else continue;

                    FieldInfo[] fields = type.GetFields(
                        BindingFlags.Public | BindingFlags.NonPublic |
                        BindingFlags.Instance
                    );

                    foreach (FieldInfo field in fields)
                    {
                        var t = field.FieldType.GetCustomAttribute<UI_TooltipAttribute>();
                        if (t != null)
                        {
                            uiTooltipComponent.Tooltip += $"\n{t.Description}";
                        }
                    }
                }
            }
        }
    }
}