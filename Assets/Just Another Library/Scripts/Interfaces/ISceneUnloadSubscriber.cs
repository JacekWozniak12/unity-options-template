using UnityEngine.SceneManagement;

public interface ISceneUnloadSubscriber
{
    void OnUnloadAction(Scene[] scenes);
}