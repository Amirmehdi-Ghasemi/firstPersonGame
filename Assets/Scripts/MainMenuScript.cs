using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    public GameObject mainMenu, optionsMenu;
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void Help()
    {
        mainMenu.SetActive(false);
        optionsMenu.SetActive(true);
    }
    public void Back()
    {
        mainMenu.SetActive(true);
        optionsMenu.SetActive(false);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
