using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("Level 1");
    }

    public void Menu()
    {
        SceneManager.LoadScene("Main Menu");
    }
    
    public void Settings()
    {

    }

    public void ExitGame()
    {

    }
}
