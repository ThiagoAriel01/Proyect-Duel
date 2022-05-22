using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnumeratorP/*Convertir a Global para acceder desde cualquier Script*/
{
    rocket,
    fog
}

public class FactoryP : MonoBehaviour
{
    private static FactoryP _intance;
    [SerializeField] GameObject moldeRocket = null;
    [SerializeField] GameObject moldeFog = null;

    Vector3 posision;

    void Awake()
    {
        posision = new Vector3(30, 0, 40);
        getIntance();
    }

    public FactoryP getIntance()
    {
        if (_intance == null)
        {
            _intance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
        return _intance;
    }

    public GameObject requestParticles(EnumeratorP particle)
    {
        GameObject newParticle = null;
        switch (particle)
        {
            case EnumeratorP.rocket:
                GameObject rocketb;
                rocketb = Instantiate(moldeRocket, posision, Quaternion.identity);
                rocketb.AddComponent<RocketTrail>();
                newParticle = rocketb;
                break;

            /*case EnumeratorP.fog:
                GameObject fog;
                fog = Instantiate(moldeFog, posision, Quaternion.identity); /*Feto vos vas a ser un nuevo enemigo
                fog.AddComponent<Fog>();
                newParticle = feto;
                break;*/
        }
        return newParticle;/*Siempre tiene q devolver algo */
    }
}
