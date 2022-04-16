using System.Collections.Generic;
using UnityEngine;

namespace JAL
{
    [System.Serializable]
    public class SceneGameObjectsContainer
    {
        public string SceneName;
        public List<GameObject> GameObjects;

        public SceneGameObjectsContainer(string name, List<GameObject> list)
        {
            SceneName = name;
            GameObjects = list;
        }
    }
}
