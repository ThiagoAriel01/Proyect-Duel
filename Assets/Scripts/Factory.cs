using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Enumerator/*Convertir a Global para acceder desde cualquier Script*/
{
    parasite,
    boss
}

public class Factory : MonoBehaviour
{
    private static Factory _intance;
    [SerializeField] GameObject moldeEnemigo = null;
    [SerializeField] GameObject moldeBoss = null;

    Vector3 posision;

    void Awake()
    {
        posision = new Vector3(30, 0, 40);
        getIntance();
    }

    public Factory getIntance()
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

    public GameObject requestEnemy(Enumerator enemy)
    {
        GameObject newEnemigo = null;
        switch (enemy)
        {
            case Enumerator.boss:
                GameObject bossito;
                bossito = Instantiate(moldeBoss, posision, Quaternion.identity);
                bossito.AddComponent<BossFinal>();
                newEnemigo = bossito;
                break;

            case Enumerator.parasite:
                GameObject feto;
                feto = Instantiate(moldeEnemigo, posision, Quaternion.identity); /*Feto vos vas a ser un nuevo enemigo*/
                feto.AddComponent<Parasite>();
                newEnemigo = feto;
                break;
        }
        return newEnemigo;/*Siempre tiene q devolver algo */
    }

}
