using System.Collections.Generic;
using UnityEngine.SceneManagement;
using System.Reflection;
using UnityEngine;
using System.Linq;
using System;

namespace JAL
{
    public class AbstractValueCollector : MonoBehaviourSingleton<AbstractValueCollector>
    {
        private List<AbstractValue> Collection = new List<AbstractValue>();
        private List<IManageValues> Managers = new List<IManageValues>();

        public void Collect(Scene[] scenes)
        {
            foreach(Scene scene in scenes)
            {
                GameObject[] root = scene.GetRootGameObjects();
            }
        }
    }
}