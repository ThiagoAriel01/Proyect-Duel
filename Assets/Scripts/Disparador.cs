using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disparador : MonoBehaviour
{
    [SerializeField] private Bala bala;
    [SerializeField] protected GameObject particulasShoot;

    public void Disparar()
    {
        GameObject.Instantiate(bala, this.transform.position, this.transform.rotation);
        GameObject.Instantiate(particulasShoot, this.transform.position, this.transform.rotation);
    }
}
