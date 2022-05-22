using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    public static bool gameIsPaused;
    [SerializeField] GameObject pause;
   
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            gameIsPaused = !gameIsPaused;
            PauseGame();
        }
        if (Input.GetKey(KeyCode.P))
        {
            gameIsPaused = !gameIsPaused;
            PauseGame();
        }
    }

    public void PauseGame()
    {
        if (gameIsPaused)
        {
            Time.timeScale = 0f;
            pause.gameObject.SetActive(true);
        }
        else
        {
            Time.timeScale = 1f;
            pause.gameObject.SetActive(false);
        }
    }
}
