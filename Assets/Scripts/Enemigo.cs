using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo : MonoBehaviour
{
    public GameObject Jugador;
    public GameObject InstanciaBala;

    public Transform cilindro;

    public float speedToLook;


    protected void ApuntarJugador()
    {
        Quaternion objetivo = Quaternion.LookRotation((Jugador.transform.position - transform.position));
        transform.rotation = Quaternion.Lerp(transform.rotation, objetivo, speedToLook * Time.deltaTime);
    }
}
