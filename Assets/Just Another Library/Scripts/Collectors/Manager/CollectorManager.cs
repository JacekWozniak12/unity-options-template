using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

using JAL.Extenders;

namespace JAL
{
    public class CollectorManager :
        MonoBehaviourSingleton<CollectorManager>,
        ISceneLoadSubscriber,
        ISceneUnloadSubscriber
    {
        public List<ICollect> Collectors = new List<ICollect>();

        public void OnLoadAction(Scene[] scenes)
        {
            StartCoroutine(CollectorsLoad(scenes));
        }

        public void OnUnloadAction(Scene[] scenes)
        {
            StartCoroutine(CollectorsUnload(scenes));
        }

        private IEnumerator CollectorsLoad(Scene[] scenes)
        {
            for (int i = 0; i < Collectors.Count; i++)
            {
                Collectors[i].CollectFrom(scenes);
                Debug.Log($"{Collectors[i].GetType().Name} loaded");
                yield return new WaitForEndOfFrame();
            }
        }

        private IEnumerator CollectorsUnload(Scene[] scenes)
        {
            for (int i = 0; i < Collectors.Count; i++)
            {
                Collectors[i].RemoveFrom(scenes);
                Debug.Log($"{Collectors[i].GetType().Name} cleaned");
                yield return new WaitForEndOfFrame();
            }
        }

        private void Start()
        {
            GetCollectors();
        }

        private void GetCollectors()
        {
            Collectors.AddRange(
                GetComponentsInChildren<ICollect>()
                );

            Collectors.OrderBy(x => x.Order);
        }
    }
}
