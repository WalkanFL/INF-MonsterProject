using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pauseMenu : MonoBehaviour
{
    public GameObject pauseMenuObject;
    public AudioSource audioSource;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pause();
        }
    }

    private void pause()
    {
        Time.timeScale = 0f;
        audioSource.pitch = 0.9f;
        pauseMenuObject.SetActive(true);

    }

    public void resume()
    {
        Time.timeScale = 1f;
        audioSource.pitch = 1;
        pauseMenuObject.SetActive(false);
    }

    public void quit()
    {
        Application.Quit();
    }
}
