using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;
    public Player player;
    public GameObject resumeButton;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            bool gameOver = player.GetGameOver();
            if (GameIsPaused)
            {
                if (gameOver)
                {
                    tomenu();
                }
                else
                {
                    Resume();
                }
                //Resume();

            }
            else
            {
                Pause();
            }

        }

    }

    //public void RestartGame()
    //{
    //    string currentSceneName = SceneManager.GetActiveScene().name;

    //    SceneManager.LoadScene(currentSceneName);
    //}
    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;


    }
    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
        bool gameOver = player.GetGameOver();
        if (resumeButton != null)
        {
            resumeButton.SetActive(!gameOver);
        }
        Time.timeScale = 0f;
        GameIsPaused = true;
    }
    public void tomenu()
    {

        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        string currentSceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(currentSceneName);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }
}
