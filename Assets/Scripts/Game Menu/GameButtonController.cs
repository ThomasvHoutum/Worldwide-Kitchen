using UnityEngine;
using UnityEngine.SceneManagement;

public class GameButtonController : MonoBehaviour
{
    [SerializeField] private GameObject _pauseUI;
    public void PauseGame()
    {
        Time.timeScale = 0f;
        _pauseUI.SetActive(true);
    }
    public void UnpauseGame()
    {
        _pauseUI.SetActive(false);
        Time.timeScale = 1.0f;
    }
    public void QuitToMenu()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("MainMenu");
    }
}
