using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace JAL
{
    public class CollectorManager :
        MonoBehaviourSingleton<CollectorManager>,
        ISceneLoadSubscriber,
        ISceneUnloadSubscriber
    {
        public List<ICollect> Collectors;

        public void OnLoadAction(Scene[] scenes)
        {
            RunCollectionLoad();
        }

        private void RunCollectionLoad()
        {
            throw new NotImplementedException();
        }

        public void OnUnloadAction(Scene[] scenes)
        {
            RunCollectionUnload();
        }

        private void RunCollectionUnload()
        {
            throw new NotImplementedException();
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
        }
    }
}
