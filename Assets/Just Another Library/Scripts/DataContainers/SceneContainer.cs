using UnityEngine;

namespace JAL
{
    [CreateAssetMenu(fileName = "SceneContainer", menuName = "unity-options-template/SceneContainer", order = 0)]
    public class SceneContainer : ScriptableObject
    {
        public string[] EntryScenes;
        public string[] LevelScenes;
    }
}