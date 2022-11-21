using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    private AsyncOperation _asyncOperation;
    private Scene _currentScene;
    private string _sceneName;

    #region Singleton pattern
    private static SceneController _instance;
    public static SceneController Instance
    {
        get
        {
            if (!_instance)
                _instance = FindObjectOfType<SceneController>();
            return _instance;
        }
    }
    #endregion

    private void Start()
    {
        AsyncLoadScene("GameScene");
    }

    public void EnableScene()
    {
        _asyncOperation.completed += AsyncOperationOnCompleted;
        _asyncOperation.allowSceneActivation = true;
    }

    public void AsyncLoadScene(string sceneName)
    {
        _sceneName = sceneName;
        _currentScene = SceneManager.GetActiveScene();
        _asyncOperation = SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);
        _asyncOperation.allowSceneActivation = false;
    }

    private void AsyncOperationOnCompleted(AsyncOperation obj)
    {
        SceneManager.SetActiveScene(SceneManager.GetSceneByName(_sceneName));
        SceneManager.UnloadSceneAsync(_currentScene);
        _asyncOperation.completed -= AsyncOperationOnCompleted;
    }
}
