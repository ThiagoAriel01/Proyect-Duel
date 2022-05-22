using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;


public class Enemy : MonoBehaviour
{

    [SerializeField] protected int shootsNecesarios = 1;
    [SerializeField] protected Animator animE;
    [SerializeField] protected GameObject humo;

    protected bool morir = false;

    [SerializeField] private AudioSource disparo,impacto;

    protected int shootsDisparados = 0;
    protected Vector3 humoPosition;

    [SerializeField] protected float rango, speed, gravedad = 9.68f;

    PlayerControler cc;
    protected CharacterController cce;

    [SerializeField] protected Transform refImpacto;
    [SerializeField] protected GameObject particulasImpacto;

    [SerializeField] protected TriggerHurt collider;

    protected void Awake()
    {
        cc = GameObject.FindWithTag("Player").GetComponent<PlayerControler>();
        cce= GetComponent<CharacterController>();
        
    }

    protected void Update()
    {
        Atacar();
    }


    public virtual void Atacar()
    {       
        if (Vector3.Distance(transform.position, cc.transform.position) <= rango)
        {
            if (!morir)
                Move();     
        }
        //fuenteSonido.Pause();
    }

    public void Move()
    {
        disparo.Play();
        Vector3 direccion = cc.transform.position - transform.position;
        direccion.y = 0;
        direccion.Normalize();
        direccion.y = direccion.y - (gravedad * Time.fixedDeltaTime);
        cce.Move(direccion * speed * Time.deltaTime);
        this.transform.LookAt(cc.transform.position);
        
    }

    public virtual void OnTriggerEnter(Collider collision)
    {       
        if (collision.gameObject.tag == "bala")
        {
            shootsDisparados += 1;
            impacto.Play();

            Instantiate(particulasImpacto, refImpacto.position, transform.rotation);

            if (shootsDisparados == shootsNecesarios)//Mate al bicho
            {
                animE.SetBool("Dead", true);
                collider.gameObject.SetActive(false);
                humoPosition = new Vector3(this.transform.position.x, -1, this.transform.position.z);
                GameObject.Instantiate(humo, humoPosition, this.transform.rotation);
                morir = true;
                shootsDisparados = 0;
            }
        }
    }
}
