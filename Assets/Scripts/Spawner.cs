using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] Factory myFactory;
    [SerializeField] Enumerator type;
    Factory factory;

    void Start()
    {
        GameObject newParasite = factory.requestEnemy(type);
        newParasite.transform.position = transform.position;
        newParasite.transform.rotation = transform.rotation;
    }

    void Awake()
    {
        factory = myFactory.GetComponent<Factory>();
    }
}
