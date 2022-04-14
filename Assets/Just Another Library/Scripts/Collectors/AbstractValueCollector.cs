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
    public class AbstractValueCollector : MonoBehaviourSingleton<AbstractValueCollector>
    {
        [SerializeField]
        private List<AbstractValue> Collection = new List<AbstractValue>();

        [SerializeField]
        private List<IManageValues> Managers = new List<IManageValues>();

        public void Collect(Scene[] scenes)
        {
            foreach (Scene scene in scenes)
            {
                GameObject[] root = scene.GetRootGameObjects();
                CollectManagersFromScene(root);
                CollectAbstractValues(root);
            }
        }

        private void CollectAbstractValues(GameObject[] rootGameObjects)
        {
            foreach (GameObject root in rootGameObjects)
            {
                // Attribute section
                var components = root.GetComponentsInChildren<IAbstractValueImplementator>();
                foreach (var childrenComponent in components)
                {
                    var type = childrenComponent.GetType();
                    var a = type.GetCustomAttribute<ValueClassSubscriberAttribute>();
                    if (a == null) continue;

                    var m = Managers.First(x => x.GetType() == a.Manager);
                    if (m == null) Debug.LogError($"Create and set manager of type {a.Manager}");

                    FieldInfo[] fields = type.GetFields(
                        BindingFlags.Public | BindingFlags.NonPublic |
                        BindingFlags.Instance
                    );

                    foreach (FieldInfo field in fields)
                    {
                        if (field.FieldType.IsSubclassOf(typeof(AbstractValue))
                            && field.GetValue(childrenComponent) is AbstractValue val)
                        {
                            Collection.Add(val);
                            m.CreateValueHandler((IValueType)val);
                        }
                    }
                }
            }
        }

        private void CollectManagersFromScene(GameObject[] root)
        {
            foreach (GameObject o in root)
            {
                // Menager section
                IManageValues[] managers = o.GetComponentsInChildren<IManageValues>();
                Managers.AddRange(managers);
            }
        }
    }
}