using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoPersecutor : Enemigo
{
    private enum TipoEnemigo
    {
        Apuntado,
        Persecucion
    }

    [SerializeField]
    private TipoEnemigo enemyType;

    public GameObject arma;

    public float speedMovement;
    private float velocidadInicial;
    public float distanciaMinima;

    void Start()
    {
        velocidadInicial = speedMovement;
    }

    // Update is called once per frame
    void Update()
    {
        switch (enemyType)
        {
            case TipoEnemigo.Apuntado:
                ApuntarJugador();
                break;

            case TipoEnemigo.Persecucion:
                ModoPersecuci�n();
                break;
        }
    }

    void ModoPersecuci�n()
    {
        if (arma != null)
        {
            arma.SetActive(false);
        }

        transform.LookAt(Jugador.transform);

        //modo seguimiento 1
        transform.position = Vector3.MoveTowards(transform.position, Jugador.transform.position, speedMovement * Time.deltaTime);

        float distance = (Jugador.transform.position - transform.position).magnitude;

        if (distance <= distanciaMinima)
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
}
