using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{

    public void Restart_Button()
    {
        SceneManager.LoadScene("Main");
    }
    public void MainMenu_btn()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void Exit_Button()
    {
        Application.Quit();
    }
}
