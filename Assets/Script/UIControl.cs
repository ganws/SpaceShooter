using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIControl : MonoBehaviour
{

    public static bool isGamePaused = false;

    //UI
    public GameObject Menu;
    public GameObject OptionMenu;
    [SerializeField] public static bool isMusicOn = true;
    [SerializeField] public static bool isSoundOn = true;
    [SerializeField] public static float GameVolume = 0.7f;

    private void Start()
    {
        Menu.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            if (isGamePaused)
                ResumeGame();
            else
                PauseGame();
    }

    public void PauseGame()
    {
        isGamePaused = true;
        Menu.SetActive(true);
        Time.timeScale = 0.0f;
    }

    public void ResumeGame()
    {
        isGamePaused = false;
        Menu.SetActive(false);
        OptionMenu.SetActive(false);
        Time.timeScale = 1.0f;
    }

    public void loadOptionMenu()
    {
        Menu.SetActive(false);
        OptionMenu.SetActive(true);
    }

    public void QuitGame()
    {
        Debug.Log("quit game");
    }

    public void RestartGame()
    {
        Debug.Log("Restart game");
    }

    public void toggleSound(bool toggle)
    {
        isSoundOn = toggle;
    }

    public void toggleMusic(bool toggle)
    {
        isMusicOn = toggle;
    }

    public void SetVolume(float vol)
    {
        GameVolume = vol;
    }

    public void GoBackMenu()
    {
        Menu.SetActive(true);
        OptionMenu.SetActive(false);
    }

}
