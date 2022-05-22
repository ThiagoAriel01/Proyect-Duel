using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    public static bool gameIsPaused;
    [SerializeField] GameObject map;
    [SerializeField] GameObject mapOpen, mapClose = null;



    void Update()
    {
        if (Input.GetKey(KeyCode.M))
        {
            gameIsPaused = !gameIsPaused;
            MapGame();
        }
    }

    public void MapGame()
    {
        if (gameIsPaused)
        {
            Time.timeScale = 0f;
            map.gameObject.SetActive(true);
            mapClose.gameObject.SetActive(true);
            mapOpen.gameObject.SetActive(false);

        }
        else
        {
            Time.timeScale = 1f;
            map.gameObject.SetActive(false);
            mapOpen.gameObject.SetActive(true);
            mapClose.gameObject.SetActive(false);

        }
    }
}
