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
    public class UITooltipCollector : MonoBehaviourSingleton<UITooltipCollector>
    {
        [SerializeField]
        private List<UITooltipCollector> Collection = new List<UITooltipCollector>();

        public void Collect(Scene[] scenes)
        {
            foreach (Scene scene in scenes)
            {
                GameObject[] root = scene.GetRootGameObjects();
                CollectAbstractValues(root);
            }
        }

        private void CollectAbstractValues(GameObject[] rootGameObjects)
        {
            foreach (GameObject root in rootGameObjects)
            {
                // Attribute section
                var components = root.GetComponentsInChildren<ITooltipAttributeImplementator>();
                foreach (var childrenComponent in components)
                {
                    var type = childrenComponent.GetType();

                    FieldInfo[] fields = type.GetFields(
                        BindingFlags.Public | BindingFlags.NonPublic |
                        BindingFlags.Instance
                    );

                    foreach (FieldInfo field in fields)
                    {
                        var t = field.FieldType.GetCustomAttribute<UI_TooltipAttribute>();
                        if (t != null)
                        {
                            if(childrenComponent is Component c)
                            {
                            }
                        }
                    }
                }
            }
        }
    }
}