using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
            //UnityEditor.EditorApplication.isPlaying = false;
        }
    }

    public void Muerte(string causa)
    {
        if (causa != "Boss")
        {
            SceneManager.LoadScene("GameOver");
        }
        else
            SceneManager.LoadScene("GameOverBoss");
    }

    public void Win()
    {
        SceneManager.LoadScene("Win");
    }
}
