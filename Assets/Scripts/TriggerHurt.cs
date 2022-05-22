using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerHurt : MonoBehaviour
{
    [SerializeField] private string causaMuerte;
    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.GetComponent<PlayerControler>().Matar(causaMuerte);
            Destroy(gameObject);            
        }
    }
}
