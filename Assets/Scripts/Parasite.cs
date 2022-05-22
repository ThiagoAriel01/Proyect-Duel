using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Parasite : Enemy
{
    Animator anim;

    void Awake()
    {
        base.Awake();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        base.Update();

        anim.SetFloat("Speed", cce.velocity.magnitude);
    }
}
