using UnityEngine;

namespace JAL
{
    [CreateAssetMenu(fileName = "SceneContainer", menuName = "unity-options-template/SceneContainer", order = 0)]
    public class SceneContainer : ScriptableObject
    {
        [Tooltip("Defines the names of Scenes that will be always loaded in App")]
        public string[] EntryScenes;

        [Tooltip("Defines the names of Scenes that will be operated upon in the App")]
        public string[] LevelScenes;
    }
}