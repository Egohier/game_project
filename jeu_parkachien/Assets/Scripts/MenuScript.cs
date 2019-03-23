using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    public void ButtonPlay()
    {
        SceneManager.LoadScene("Park");
    }

    public void ButtonExit()
    {
        Application.Quit();
    }
}
