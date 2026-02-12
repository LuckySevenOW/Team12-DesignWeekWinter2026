using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    //Dis one is for the start button
    public void LoadScene()
    {
        SceneManager.LoadScene(1);
    }

    //This stuff is for the info pop up screen, to hide it and show it when the button is clicked
    public GameObject infoScreen;

    public void ShowScreen()
    {
        infoScreen.SetActive(true);
    }

    public void HideScreen()
    {
        infoScreen.SetActive(false);
    }

    //Dis for the quit button
    public void QuitGame()
    {
        Application.Quit();
    }
}
