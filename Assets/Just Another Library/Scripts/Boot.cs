using UnityEngine;
using UnityEngine.SceneManagement;

namespace JAL
{
    public class Boot : MonoBehaviourSingleton<Boot>
    {
        [SerializeField]
        public SceneContainer SceneContainer;

        [Header("Style Containers")]
        [SerializeField]
        public UIStyleContainer DefaultUIStyle;

        void Start()
        {
            foreach (string sceneName in SceneContainer.EntryScenes)
            {
                if (!SceneManager.GetSceneByName(sceneName).IsValid())
                    SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);
            }
        }
    }
}

