using UnityEngine.SceneManagement;
using UnityEngine;

using System.Collections.Generic;
using System.Reflection;
using System.Linq;
using System;

namespace JAL
{
    /// <summary>
    /// Handles the subscription via ValueClassSubscriberAttribute
    /// </summary>
    public class AbstractValueCollector : MonoBehaviourSingleton<AbstractValueCollector>, ISceneLoadSubscriber, ICollect
    {
        [SerializeField]
        private List<AbstractValue> Collection = new List<AbstractValue>();

        [SerializeField]
        private List<IManageValues> Managers = new List<IManageValues>();

        public void OnLoadAction(Scene[] scenes) => Collect(scenes);

        public void Collect(Scene[] scenes)
        {
            foreach (Scene scene in scenes)
            {
                GameObject[] root = scene.GetRootGameObjects();
                CollectValueManagersFromScene(root);
                CollectAbstractValues(root);
            }
        }

        private void CollectAbstractValues(GameObject[] rootGameObjects)
        {
            foreach (GameObject root in rootGameObjects)
            {
                // Attribute section
                var components = root.GetComponentsInChildren<IValueAttributeImplementator>();
                CreateValueHandlersInComponents(components);
            }
        }

        private void CreateValueHandlersInComponents(IValueAttributeImplementator[] components)
        {
            foreach (var childrenComponent in components)
            {
                // Get custom attribute
                var type = childrenComponent.GetType();
                var a = type.GetCustomAttribute<ValueClassSubscriberAttribute>();
                if (a == null) continue;

                // Get manager
                var m = Managers.First(x => x.GetType() == a.Manager);
                if (m != null) CreateValueHandlersFromFields(childrenComponent, type, m);
                else Debug.LogError($"Create and set manager of type {a.Manager}");
            }
        }

        private void CreateValueHandlersFromFields(
            IValueAttributeImplementator childrenComponent,
            Type type,
            IManageValues manager)
        {
            FieldInfo[] fields = type.GetFields(
                BindingFlags.Public | BindingFlags.NonPublic |
                BindingFlags.Instance
            );

            foreach (FieldInfo field in fields)
                CreateValueHandlerFromField(childrenComponent, manager, field);
        }

        private void CreateValueHandlerFromField(
            IValueAttributeImplementator childrenComponent,
            IManageValues manager,
            FieldInfo field)
        {
            if (field.FieldType.IsSubclassOf(typeof(AbstractValue))
                && field.GetValue(childrenComponent) is AbstractValue val)
            {
                Collection.Add(val);
                manager.CreateValueHandler((IValueType)val);
            }
        }

        private void CollectValueManagersFromScene(GameObject[] root)
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