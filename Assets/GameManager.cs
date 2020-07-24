using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public Text scoreText;

    public float RestartDelay = 2.0f;
    private bool gamehasEnded = false;
    public int CurrentLevel = 1;
    public int maxLevel = 10;
    public int Score = 0;


    //Level Progression Management
    [SerializeField] private float updateLevelDuration = 20.0f; // duration to increase difficulty


    //UI Menu
    //public GameObject menuPrefabs;


    public void Start()
    {
        updateScore();
        StartCoroutine("levelProgression");

    }

    public void endGame()
    {
        if (gamehasEnded == false)
        {
            gamehasEnded = true;
            Invoke("Restart", RestartDelay);
        }
    }

    public void Restart()
    {
        gamehasEnded = false;
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void addScore(int addscore)
    {
        Score += addscore;
        updateScore();
    }

    private void updateScore()
    {
        scoreText.text = "SCORE: " + Score.ToString("D4");
    }

    IEnumerator levelProgression()
    {

        while(true)
        {
            CurrentLevel++;
            if (CurrentLevel >= maxLevel)
                CurrentLevel = maxLevel;

            FindObjectOfType<SpawnMeteor>().increaseLvlMod(CurrentLevel, maxLevel);
            Debug.Log("Level Increase!");

            yield return new WaitForSeconds(updateLevelDuration);
        }

    }

    public void QuitGame()
    {
        Application.Quit();
    }

    //private void Update()
    //{
    //    if (Input.GetKeyDown(KeyCode.Escape))
    //        openMenu();
    //}

    //public void openMenu()
    //{
    //    Instantiate(menuPrefabs);
    //}

}
