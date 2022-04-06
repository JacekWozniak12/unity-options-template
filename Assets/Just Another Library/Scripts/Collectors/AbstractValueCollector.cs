using System.Collections.Generic;
using UnityEngine.SceneManagement;
using System.Reflection;
using UnityEngine;
using System.Linq;
using System;

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

        private void CollectAbstractValues(GameObject[] root)
        {
            foreach (GameObject o in root)
            {
                // Attribute section
                IAbstractValueImplementator[] col = o.GetComponentsInChildren<IAbstractValueImplementator>();
                foreach (var c in col)
                {
                    Type type = c.GetType();
                    ValueClassSubscriberAttribute a = type.GetCustomAttribute<ValueClassSubscriberAttribute>();
                    if (a == null) continue;
                    var m = Managers.First(x => x.GetType() == a.Manager);

                    FieldInfo[] fields = type.GetFields(
                        BindingFlags.NonPublic |
                        BindingFlags.Instance
                    );

                    foreach (FieldInfo field in fields)
                    {
                        if (field.FieldType.IsSubclassOf(typeof(AbstractValue)))
                        {
                            
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