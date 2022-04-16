using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace JAL
{
    public class SceneGameObjectCollector :
        MonoBehaviourSingleton<SceneGameObjectCollector>,
        ICollect
    {
        [SerializeField]
        private List<SceneGameObjectsContainer> sceneObjects
            = new List<SceneGameObjectsContainer>();

        public int Order => 1;

        public void CollectFrom(Scene[] scenes)
        {
            foreach (Scene scene in scenes)
            {
                GameObject[] roots = scene.GetRootGameObjects();
                List<GameObject> temp = new List<GameObject>();
                temp.AddRange(roots);

                foreach (GameObject gameObject in roots)
                    GetChildRecursiveIntoList(gameObject, ref temp);

                sceneObjects.Add(new SceneGameObjectsContainer(scene.name, temp));
            }
        }

        public void RemoveFrom(Scene[] scenes)
        {
            foreach (Scene scene in scenes)
                sceneObjects.Remove(sceneObjects.Find(x => x.SceneName == scene.name));
        }

        public GameObject[] GetGameObjectsFromScene(Scene scene)
            => sceneObjects.Find(x => x.SceneName == scene.name).GameObjects.ToArray();

        private void GetChildRecursiveIntoList(GameObject gameObject, ref List<GameObject> list)
        {
            if (null == gameObject) return;

            foreach (Transform child in gameObject.transform)
            {
                if (null == child) continue;
                list.Add(child.gameObject);
                GetChildRecursiveIntoList(child.gameObject, ref list);
            }
        }
    }
}
