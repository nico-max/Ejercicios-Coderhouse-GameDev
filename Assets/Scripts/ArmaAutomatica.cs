using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmaAutomatica : MonoBehaviour
{
    // Para tener el lugar y la dirección en que aparece la bala
    public GameObject instanciaBala;
    public Transform cilindro;

    // Velocidad de disparo
    public float fireRate;

    // Disparos automaticos
    public bool disparosRestantes;
    public float counter;


    public float tiempoDestruccion;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Z))
        {
            disparosRestantes = !disparosRestantes;
        }
        

        if(disparosRestantes)
        {
            Disparos();
        }
        else
        {
            counter = 0;
        }
    }

    void Disparos()
    {
        counter -= Time.deltaTime;

        if (counter <= 0)
        {
            Disparo();
            reiniciarContador();
        }

    }

    void reiniciarContador()
    {
        counter = fireRate;
    }

    void Disparo()
    {
        Instantiate(instanciaBala, cilindro.position, transform.rotation);
    }
}
