using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WelcomeScript : MonoBehaviour
{
    private string email;
    private string username;
    private string password;

    public void QuitGame()
    {
        Application.Quit();
    }


    public void GoToMenu()
    {
        //if (!string.IsNullOrEmpty(user) && !string.IsNullOrEmpty(pass)) //si aici trebuie validate username-ul si parola
        SceneManager.LoadScene("MainMenu");
    }

    public void SignUp()
    {
        SceneManager.LoadScene("SignUpScene");
    }

    public void SetEmail(string input)
    {
        if(!string.IsNullOrEmpty(input))
            this.email = input; //aici ar trebui sa fie o functie care trimite efectiv un mail cu parola specifica dupa ce se face apel la db
    }
}
