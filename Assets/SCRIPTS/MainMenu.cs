using UnityEngine.SceneManagement;
using UnityEngine;

public class MainMenu: MonoBehaviour
{
    [SerializeField] private string singleplayerSceneName = "conduccion9";
    [SerializeField] private string multiplayerSceneName = "conduccion10";
    [SerializeField] private string creditsSceneName = "Credits";
    [SerializeField] private string mainMenuSceneName = "Menu";

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void PlaySingleplayer()
    {
        LoadScene(singleplayerSceneName);
    }
    public void PlayMultiplayer()
    {
        LoadScene(multiplayerSceneName);
    }

    public void ShowCredits()
    {
        LoadScene(creditsSceneName);
    }

    public void GoMainMenu()
    {
        LoadScene(mainMenuSceneName);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}

