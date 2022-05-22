using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnParticles : MonoBehaviour
{
    [SerializeField] FactoryP myFactory;
    [SerializeField] RocketTrail rocket;
    FactoryP factory;

    void Start()
    {
        GameObject newRocket = factory.requestParticles(EnumeratorP.rocket);
        newRocket.transform.position = transform.position;
        newRocket.transform.rotation = transform.rotation;
    }

    void Awake()
    {
        factory = myFactory.GetComponent<FactoryP>();
    }
}
