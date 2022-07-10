using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dinamicas : MonoBehaviour
{
    private bool achiquitado;
    private bool puedeCambiar;

    private float cooldown = 2f;
    private float counter;


    private float counterPared;
    private float tiempoCambio;

    // Start is called before the first frame update
    void Start()
    {
        achiquitado = false;
        puedeCambiar = true;
    }

    // Update is called once per frame
    void Update()
    {
        cooldownCrecimiento();
    }

    private void OnTriggerEnter(Collider other)
    {
        Shrinker colisionador = other.GetComponent<Shrinker>();

        if(colisionador != null)
        {
            Debug.Log("Colisionando con: " + other.transform.gameObject.name + " el cual tiene Shrinker");
        }
        else
        {
            Debug.Log("Colisionando con: " + other.transform.gameObject.name);
        }
        
    }

    void cooldownCrecimiento()
    {
        if(counter>=0)
        {
            counter -= Time.deltaTime;
        }
        else
        {
            puedeCambiar = true;
        }
    }

    void reiniciarTemporizador()
    {
        counter = cooldown;
    }

    private void OnTriggerExit(Collider colision)
    {
        if(colision.transform.gameObject.name == "ShrinkerWall" && puedeCambiar)
        {
            if(achiquitado)
            {
                transform.localScale = new Vector3(3, 3, 3);
                achiquitado = false;
                puedeCambiar = false;
                reiniciarTemporizador();
            }
            else
            {
                transform.localScale = new Vector3(1, 1, 1);
                achiquitado = true;
                puedeCambiar = false;
                reiniciarTemporizador();
            }
        }
    }


    private void OnTriggerStay(Collider other)
    {
        if (other.transform.gameObject.name == "BumpWall")
        {
            temporizadorCambioPared();
            if(counterPared>=tiempoCambio)
            {
                float posZ = Random.Range(-56f, 36f);
                float posX = Random.Range(-30f, 30f);

                other.transform.position = new Vector3(posX, 0, posZ);
                reiniciarTemporizadorPared();
            }
        }

    }

    void temporizadorCambioPared()
    {
        if (counterPared <= tiempoCambio)
        {
            counterPared += Time.deltaTime;
        }
    }

    void reiniciarTemporizadorPared()
    {
        counterPared = 0; 
    }

}
