using UnityEngine.SceneManagement;

public interface ISceneLoadSubscriber
{
    void OnLoadAction(Scene[] scenes);
}