using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using Facebook.Unity;
//using ElephantSDK;

public class GameController : Singleton<GameController>
{
    public bool GameStarted;
    public GameObject FailedText, LevelCompletedText, TapToStartText;
    public GameObject PlayAgainButton, NextLevelButton;

    private bool readyToStart;

    // Start is called before the first frame update
    void Start()
    {
        //FB.Init();

        GameStarted = false;
        readyToStart = true;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButton(0))
        {

            if (readyToStart && !GameStarted)
            {
                GameStarted = true;
                readyToStart = false;
                TapToStartText.SetActive(false);

                //Elephant.LevelStarted(LevelController.Instance.CurrentLevelId + 1);
            }
        }

}

    public void LevelCompleted()
    {
        //Elephant.LevelCompleted(LevelController.Instance.CurrentLevelId + 1);

        LevelController.Instance.LevelCompleted();

        GameStarted = false;
        LevelCompletedText.SetActive(true);
        NextLevelButton.SetActive(true);
    }

    public void Reset()
    {
        Destroy(LevelController.Instance.CurrentLevel.gameObject);

        LevelController.Instance.InstantiateNewLevel(LevelController.Instance.CurrentLevelId);
    }

    public void GameOver()
    {
        //Elephant.LevelFailed(LevelController.Instance.CurrentLevelId + 1);

        GameStarted = false;
        FailedText.SetActive(true);
        PlayAgainButton.SetActive(true);
    }

    public void PlayAgainButtonClick()
    {
        Reset();

        FailedText.SetActive(false);
        PlayAgainButton.SetActive(false);
        TapToStartText.SetActive(true);

        readyToStart = true;
    }

    public void NextLevelButtonClick()
    {
        LevelController.Instance.NextLevel();

        LevelCompletedText.SetActive(false);
        NextLevelButton.SetActive(false);
        TapToStartText.SetActive(true);
        
        readyToStart = true;
    }
}
