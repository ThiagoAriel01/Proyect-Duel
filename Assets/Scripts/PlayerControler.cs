using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;

public class PlayerControler : MonoBehaviour
{
    [SerializeField] float movimiento = 10f, gravedad = 9.68f;

    [SerializeField] private Light linterna;

    float rotacionX, rotacionY, velocidadRotacion = 100f;

    [SerializeField] Transform camara;

    [SerializeField] Animator anim;

    [SerializeField] private float firaRate, timerDisparo;
    private bool puedeDisparar;
    [SerializeField] private Disparador disparador;

    [SerializeField] AudioSource shoot;

    Vector3 eje;
    CharacterController cc;

    [SerializeField] LevelManager manager;

    private void Awake()
    {
        cc=GetComponent<CharacterController>();           
    }

    public void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; //Bloquea el cursor en el centro de la pantalla
        Cursor.visible = false; //Hace invisible el cursor
    }

    void Update()
    {
        GetInput();
        Rotate();

        if (puedeDisparar==false)               //La ballesta puede disparar de a una flecha por vez cada 2 segundos 
        {                                       //q es lo q tarda la animacionen completarse
            timerDisparo -= Time.deltaTime;
            if (timerDisparo<=0)
                puedeDisparar = true;
        }
    }

    public void Move()
    {
        eje = transform.forward * eje.z + transform.right * eje.x; //PREGUNTAR A ALAN
        eje.Normalize();
        eje.y = eje.y - (gravedad * Time.fixedDeltaTime);
        cc.Move(eje * movimiento * Time.fixedDeltaTime);
        // + (new Vector3(0, eje.y, 0) * gravedad * Time.fixedDeltaTime)
    }
    public void FixedUpdate()
    {
        Move();
    }

    public void GetInput()
    {
        eje.z = 0;
        eje.x = 0;
        
        if (Input.GetKey(KeyCode.W))
        {
            eje.z = 1;
        }
        if (Input.GetKey(KeyCode.S))
        {
            eje.z = -1;
        }
        if(Input.GetKey(KeyCode.A))
        {
            eje.x = -1;
        }
        if (Input.GetKey(KeyCode.D))
        {
            eje.x = 1;
        }

        //IZQUIERDA
        if (Input.GetMouseButtonDown(0))
        {
            if (puedeDisparar)
            {
                disparador.Disparar();
                shoot.Play();
                timerDisparo = firaRate;
                anim.SetTrigger("Disparar");
                puedeDisparar = false;
            }          
        }
        //DERECHA
        if (Input.GetMouseButtonDown(1))
        {
            linterna.enabled = !linterna.enabled;//Enciende y apaga el PointLight
        }
    }

    //Mathf.Clamp(valor,minimo,maximo) transform.localEulerAngles  //Probando funciones para conseguir q el mouse no tenga un giro infinito

    public void Rotate()
    {
        rotacionX = Input.GetAxis("Mouse X");
        transform.Rotate(0, rotacionX * velocidadRotacion * Time.fixedDeltaTime, 0);
        rotacionY = -Input.GetAxis("Mouse Y");
        camara.Rotate(rotacionY * velocidadRotacion * Time.fixedDeltaTime, 0, 0);
        //camara.localEulerAngles=new Vector3(ClampAngle(camara.localEulerAngles.x,  -90,  90),0,0);
        camara.localRotation = ClampRotationAroundXAxis(camara.localRotation);
    }

    Quaternion ClampRotationAroundXAxis(Quaternion q) //Consigue bloquear el movimiento del mouse entre 90| y -90°
    {
        q.x /= q.w;
        q.y /= q.w;
        q.z /= q.w;
        q.w = 1.0f;
        float angleX = 2.0f * Mathf.Rad2Deg * Mathf.Atan(q.x);
        angleX = Mathf.Clamp(angleX, -90, 90);
        q.x = Mathf.Tan(0.5f * Mathf.Deg2Rad * angleX);
        return q;
    }

    public void Matar(string causa)
    {
        manager.Muerte(causa);
    }
}
