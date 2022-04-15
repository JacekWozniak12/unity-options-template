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
        [Tooltip("Gets children Monobehaviours that have ICollect and ISceneLoadSubscriber")]
        public GameObject CollectorsContainer;

        [Header("Style")]
        public UIStyleContainer DefaultUIStyle;

        private System.Action<Scene[]> onScenesLoaded;
        private System.Action<Scene[]> onScenesUnloaded;

        private void Start()
        {
            GetCollectors();
            StartCoroutine(LoadEntryScenes());
        }

        private void GetCollectors()
        {
            var collectors = CollectorsContainer.GetComponentsInChildren<ICollect>();
            foreach (ICollect collector in collectors)
            {
                if (collector is ISceneLoadSubscriber s)
                    onScenesLoaded += s.OnLoadAction;
            }
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

