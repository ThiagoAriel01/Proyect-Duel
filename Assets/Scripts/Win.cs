using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Win : MonoBehaviour
{
    [SerializeField] LevelManager win;

    public void OnTriggerEnter(Collider collision)
    {
        win.Win();
    }
}
