using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ejercicio2 : MonoBehaviour
{
    public int vida;
    public float velocidad;
    public Vector3 direccion;

    public bool danoJugador;
    public bool curaJugador;


    // Start is called before the first frame update
    void Start()
    {
        vida = 3;
        velocidad = 0.1f;
        direccion = new Vector3(1, 0, 0);
        danoJugador = false;
        curaJugador = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(danoJugador)
        {
            danarJugador();
        }
        else if(curaJugador)
        {
            curarJugador();
        }

        controlMovimiento();
    }

    void danarJugador()
    {
        vida--;
    }

    void curarJugador()
    {
        vida++;
    }

    void controlMovimiento()
    {
        transform.Translate(direccion * velocidad * Time.deltaTime);
    }

}
