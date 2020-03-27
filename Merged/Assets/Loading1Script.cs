using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Loading1Script : MonoBehaviour
{
    public void GoToLogin()
    {
        SceneManager.LoadScene("LogInScene");
    }
}
