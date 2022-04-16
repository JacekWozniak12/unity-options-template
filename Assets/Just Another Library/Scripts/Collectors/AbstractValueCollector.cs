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
    public class AbstractValueCollector : MonoBehaviourSingleton<AbstractValueCollector>, ICollect
    {
        [SerializeField]
        private List<AbstractValue> Collection = new List<AbstractValue>();

        [SerializeField]
        private List<IManageValues> Managers = new List<IManageValues>();

        public int Order => 2;

        public void CollectFrom(Scene[] scenes)
        {
            List<GameObject> temp = new List<GameObject>();

            foreach (Scene scene in scenes)
            {
                var objects = SceneGameObjectCollector.Instance.GetGameObjectsFromScene(scene);
                temp.AddRange(objects);
            }
            CollectValueManagersFromScene(temp.ToArray());
            CollectAbstractValues(temp.ToArray());
        }

        public void RemoveFrom(Scene[] scenes)
        {
            return;
        }

        private void CollectAbstractValues(GameObject[] gameObjects)
        {
            var ListValueImplementator = new List<IValueAttributeImplementator>();

            foreach (var gameObject in gameObjects)
            {
                var c = gameObject.GetComponent<IValueAttributeImplementator>();
                if (c != null) ListValueImplementator.Add(c);
            }

            CreateValueHandlersInComponents(ListValueImplementator.ToArray());
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
                
                if (m != null)
                    CreateValueHandlersFromFields(childrenComponent, type, m);
                else
                    Debug.LogError($"Create and set manager of type {a.Manager}");
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

        private void CollectValueManagersFromScene(GameObject[] objects)
        {
            foreach (GameObject o in objects)
            {
                // Menager section
                IManageValues[] managers = o.GetComponentsInChildren<IManageValues>();
                Managers.AddRange(managers);
            }
        }
    }
}