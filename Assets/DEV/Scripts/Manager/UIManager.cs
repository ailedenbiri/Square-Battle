using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField] GameObject pauseButton;
    [SerializeField] GameObject playButton;
    [SerializeField] GameObject quitButton;

    private void Awake()
    {
        pauseButton.SetActive(true);
        playButton.SetActive(false);
        quitButton.SetActive(true);
    }

    public void Play()
    {
        Time.timeScale = 1.0f;
        pauseButton.SetActive(true);
        playButton.SetActive(false);

    }

    public void PauseGame()
    {
        Time.timeScale = 0;
        playButton.SetActive(true);
        pauseButton.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
