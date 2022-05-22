using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour   
{
    [SerializeField] private AudioClip[] eat;
    [SerializeField] private AudioSource fuenteSonido;
    private float timer;
    [SerializeField] private float timerSound;
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
            SceneManager.LoadScene("SceneMenu");
        if (Input.GetKey(KeyCode.Space))
            SceneManager.LoadScene("RealyRestart");
        if (Input.GetKey(KeyCode.Return))
            SceneManager.LoadScene("Level");
        Sound();
        timer -= Time.deltaTime;
    }

    void Sound()
    {
        if (timer<=0)
        {
            timer = timerSound;
        }
        fuenteSonido.clip = eat[Random.Range(0, eat.Length)];
        fuenteSonido.Play();
    }
}
