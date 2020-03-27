using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    public void GoToLogin()
    {
        SceneManager.LoadScene("LogInScene");
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("PlayScene");
    }
}
