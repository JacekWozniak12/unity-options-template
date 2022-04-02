using UnityEngine;

namespace JAL
{
    /// <summary>
    /// Uses Awake() message and gives static Instance.
    /// T is the component implementing the abstraction
    /// <para/> 
    /// Component of type T is destroyed if there is a instance
    /// </summary>
    /// <typeparam name="T">Self implementing generic</typeparam>
    public abstract class MonoBehaviourSingleton<T> : MonoBehaviour where T : MonoBehaviourSingleton<T>
    {
        protected virtual string Name() => $"Singleton {typeof(T)}";

        public static T Instance
        {
            get;
            private set;
        }
        private void DisplayMessage() => Debug.LogWarning($"Component of type {typeof(T)} already exists on {Instance.gameObject}", Instance.gameObject);
        protected virtual void Awake()
        {
            if (Instance != null && Instance != this)
            {
                DisplayMessage();
                Destroy(this);
            }
            else Instance = this as T;
        }
    }
}