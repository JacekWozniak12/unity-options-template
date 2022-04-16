using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace JAL
{
    public class SceneGameObjectCollector :
        MonoBehaviourSingleton<SceneGameObjectCollector>,
        ISceneLoadSubscriber,
        ICollect
    {
        [SerializeField]
        private List<SceneContainerForGameObjects> sceneObjects
            = new List<SceneContainerForGameObjects>();

        public void OnLoadAction(Scene[] scenes) => CollectFrom(scenes);
        public void OnUnloadAction(Scene[] scenes) => RemoveFrom(scenes);

        public GameObject[] GetGameObjectsFromScene(Scene scene)
            => sceneObjects.Find(x => x.SceneName == scene.name).GameObjects.ToArray();

        public void CollectFrom(Scene[] scenes)
        {
            foreach (Scene scene in scenes)
            {
                GameObject[] roots = scene.GetRootGameObjects();
                List<GameObject> temp = new List<GameObject>();

                foreach (GameObject gameObject in roots)
                    GetChildRecursiveIntoList(gameObject, ref temp);

                sceneObjects.Add(new SceneContainerForGameObjects(scene.name, temp));
            }
        }

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

        private void RemoveFrom(Scene[] scenes)
        {
            foreach (Scene scene in scenes)
                sceneObjects.Remove(sceneObjects.Find(x => x.SceneName == scene.name));
        }
    }

    [System.Serializable]
    public class SceneContainerForGameObjects
    {
        public string SceneName;
        public List<GameObject> GameObjects;

        public SceneContainerForGameObjects(string name, List<GameObject> list)
        {
            SceneName = name;
            GameObjects = list;
        }
    }
}
