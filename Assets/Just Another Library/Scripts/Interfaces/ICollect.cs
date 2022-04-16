using UnityEngine.SceneManagement;

public interface ICollect
{
    void CollectFrom(Scene[] scenes);
    int Order { get; }
    System.Action CollectionStarted { get; }
    System.Action CollectionEnded { get; }
}