using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private enum TipoEnemigo
    {
        Apuntado,
        Persecucion
    }


    [SerializeField]
    private TipoEnemigo enemyType;

    public GameObject Jugador;
    public float speedToLook;
    public float speedMovement;

    public float distanciaMinima;

    public Transform torreta;

    private float velocidadInicial;

    public GameObject arma;

    void Start()
    {
        velocidadInicial = speedMovement;
    }

    // Update is called once per frame
    void Update()
    {
        switch(enemyType)
        {
            case TipoEnemigo.Apuntado:
                ModoApuntado();
                break;

            case TipoEnemigo.Persecucion:
                ModoPersecución();
                break;
        }
    }

    void ModoPersecución()
    {
        if(arma != null)
        {
            arma.SetActive(false);
        }

        transform.LookAt(Jugador.transform);

        //modo seguimiento 1
        transform.position = Vector3.MoveTowards(transform.position, Jugador.transform.position, speedMovement * Time.deltaTime);

        float distance = (Jugador.transform.position - transform.position).magnitude;

        if(distance <= distanciaMinima)
        {
            speedMovement = 0;
        }
        else
        {
            speedMovement = velocidadInicial;
        }

        /**
         * Modo seguimiento 2
         * Vector3 direction = (Jugador.transform.position - transform.position).normalized;
         * transform.position += direction * speedMovement * Time.deltaTime;
         */
    }

    void ModoApuntado()
    {
        if (arma != null)
        {
            arma.SetActive(true);
        }

        Quaternion objetivo = Quaternion.LookRotation((Jugador.transform.position - transform.position));
        transform.rotation = Quaternion.Lerp(transform.rotation, objetivo, speedToLook * Time.deltaTime);

        //torreta.LookAt(Jugador.transform);
    }
}
