using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    // Start is called before the first frame update


    public void Play_Btn()
    {
        SceneManager.LoadScene("Main");
    }
    public void Exit_Btn()
    {
        Application.Quit();
    }
}
