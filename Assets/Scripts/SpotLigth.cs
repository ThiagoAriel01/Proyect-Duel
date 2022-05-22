using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using UnityEngine;

public class SpotLigth : MonoBehaviour
{
    void Update()
    {
        if (transform.position.y>0)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y -1.8f, transform.position.z);
        }
    }
}
