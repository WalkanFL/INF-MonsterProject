using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pauseMenu : MonoBehaviour
{
    public GameObject pauseMenuObject;

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
        pauseMenuObject.SetActive(true);

    }

    public void resume()
    {
        Time.timeScale = 1f;
        pauseMenuObject.SetActive(false);
    }

    public void quit()
    {
        Application.Quit();
    }
}
