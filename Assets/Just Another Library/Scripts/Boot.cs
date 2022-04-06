using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using System.Collections;

namespace JAL
{
    public class Boot : MonoBehaviourSingleton<Boot>
    {
        [SerializeField]
        public SceneContainer SceneContainer;

        [Header("Style Containers")]
        [SerializeField]
        public UIStyleContainer DefaultUIStyle;

        public System.Action<Scene[]> onScenesLoaded;
        public System.Action<Scene[]> onScenesUnloaded;

        void Start()
        {
            AbstractValueCollector abstractValueCollector = gameObject.AddComponent<AbstractValueCollector>();
            onScenesLoaded += abstractValueCollector.Collect;
            StartCoroutine(LoadEntryScenes());
        }

        IEnumerator LoadEntryScenes()
        {
            List<Scene> ScenesLoaded = new List<Scene>();

            foreach (string sceneName in SceneContainer.EntryScenes)
            {
                if (!SceneManager.GetSceneByName(sceneName).IsValid())
                {
                    yield return SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);
                    ScenesLoaded.Add(SceneManager.GetSceneByName(sceneName));
                }
            }
            yield return new WaitForEndOfFrame();
            onScenesLoaded?.Invoke(ScenesLoaded.ToArray());
        }
    }
}

