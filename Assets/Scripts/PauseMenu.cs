using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    private bool isGamePaused = false;
    public bool isGameOver = false;

    public GameObject Pause_Men;
    public GameObject Player, pistol;

    public AudioSource msc;
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) && (!isGameOver))
        {
            if(!isGamePaused)
            {
                PauseGame();

            }
            else
            {
                Resume();
            }
        }
    }
    private void PauseGame()
    {
        Time.timeScale = 0;
        msc.Pause();
        Player.GetComponent<PlayerMovement>().enabled = false;

        pistol.GetComponent<SyringaController>().enabled = false;

        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        Pause_Men.SetActive(true);



        //set bool
        isGamePaused = true;
    }
    private void Resume()
    {
        Time.timeScale = 1;
        msc.UnPause();
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        Player.GetComponent<PlayerMovement>().enabled = true;
        pistol.GetComponent<SyringaController>().enabled = true;


        Pause_Men.SetActive(false);
        isGamePaused = false;
    }

    public void Exitgame()
    {
        Application.Quit();
    }
    public void OpenMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    
}
