using UnityEngine.SceneManagement;

public interface ICollect
{
    void CollectFrom(Scene[] scenes);
    void RemoveFrom(Scene[] scenes);
    
    int Order { get; }
}