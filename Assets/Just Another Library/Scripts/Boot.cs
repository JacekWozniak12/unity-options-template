using System.Globalization;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using System.Collections;

namespace JAL
{
    public class Boot : MonoBehaviourSingleton<Boot>
    {
        [Header("Initialization")]
        [SerializeField]
        public SceneContainer SceneContainer;

        [SerializeField]
        public CollectorManager CollectorManager;

        [Header("Style")]
        public UIStyleContainer DefaultUIStyle;

        private System.Action<Scene[]> onScenesLoaded;
        private System.Action<Scene[]> onScenesUnloaded;

        private void Start()
        {
            CollectorManager = CollectorManager.Instance;
            onScenesLoaded += CollectorManager.OnLoadAction;
            StartCoroutine(LoadEntryScenes());
        }

        private IEnumerator LoadEntryScenes()
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

