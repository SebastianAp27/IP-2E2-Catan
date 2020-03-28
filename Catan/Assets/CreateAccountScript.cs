using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreateAccountScript : MonoBehaviour
{
    public void GoToLogin()
    {
        SceneManager.LoadScene("LogInScene");
    }
}
