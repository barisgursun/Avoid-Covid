using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : Singleton<LevelController>
{
    public GameObject[] LevelPrefabs;

    [HideInInspector]
    public int CurrentLevelId;
    [HideInInspector]
    public Level CurrentLevel;
    [HideInInspector]
    public bool IsLevelCompleted = false;
    
    private Level prevLevel;
    private int levelCount;

    void Awake()
    {
        CurrentLevelId = PlayerPrefs.GetInt("currentLevel", 0);
        levelCount = LevelPrefabs.Length;
    }

    // Start is called before the first frame update
    void Start()
    {
        InstantiateNewLevel(CurrentLevelId);
    }

    public void LevelCompleted()
    {
        IsLevelCompleted = true;
        prevLevel = CurrentLevel;

        CurrentLevelId++;

        PlayerPrefs.SetInt("currentLevel", CurrentLevelId);
        PlayerPrefs.Save();
    }

    public void NextLevel()
    {
        prevLevel.gameObject.SetActive(false);
        Destroy(prevLevel.gameObject);

        InstantiateNewLevel(CurrentLevelId);

        CurrentLevel.gameObject.SetActive(true);
    }

    public void InstantiateNewLevel(int levelId)
    {
        var newLevel = Instantiate(LevelPrefabs[levelId % levelCount]);

        CurrentLevel = newLevel.GetComponent<Level>();

        newLevel.transform.SetParent(transform);
        newLevel.SetActive(true);
    }
}
