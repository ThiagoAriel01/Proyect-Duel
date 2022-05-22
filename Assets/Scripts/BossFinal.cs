using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossFinal : Enemy
{
    [SerializeField] LevelManager win2;

    private bool activarTimer = false, activarTimer2=false;
    private float timer=0,contador=0;
    [SerializeField] private GameObject lava;
    [SerializeField] private Transform RefPosisionlava;
    [SerializeField] private float timer2;

    void Awake()
    {
        base.Awake();
        animE = GetComponent<Animator>();
    }

    void Update()
    {
        base.Update();
        animE.SetFloat("Speed", cce.velocity.magnitude);

        if (activarTimer2)
        {
            timer += Time.fixedDeltaTime;
            if (timer >= 4f)
            {
                RefPosisionlava.transform.position = new Vector3(this.transform.position.x, -1, this.transform.position.z);
                GameObject.Instantiate(lava, RefPosisionlava.position, this.transform.rotation);
                timer = 0;
            }
        }

        if (activarTimer)
        {
            timer2 += Time.fixedDeltaTime;
            if (timer2>=3.5f)
            {
                win2.Win();
            }
        }
    }

    void OnTriggerEnter(Collider collision)
    {
        base.OnTriggerEnter(collision);
        if (collision.gameObject.tag == "bala")
        {
            contador++;
            if (contador >= 3)
            {
                activarTimer = true;
                contador = 0;
            }
            activarTimer2 = true;
        }
    }
}
