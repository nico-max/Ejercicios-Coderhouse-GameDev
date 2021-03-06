using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arma : MonoBehaviour
{
    public GameObject instanciaBala;
    public Transform cilindro;

    public float fireRate;

    public int disparosRestantes;
    public float counter;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            //Transform cilindro = transform.GetChild(0).gameObject.transform;
            //instanciaBala.GetComponent<Bala>().setDirection(cilindro.transform);

            Disparo();
        }
        else if(Input.GetKeyDown(KeyCode.J))
        {
            disparosRestantes += 2;
        }
        else if (Input.GetKeyDown(KeyCode.K))
        {
            disparosRestantes += 3;
        }
        else if (Input.GetKeyDown(KeyCode.L))
        {
            disparosRestantes += 4;
        }

        if(disparosRestantes>0)
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

        if ((disparosRestantes > 0) && (counter <= 0))
        {
            Disparo();
            reiniciarContador();
            disparosRestantes--;
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
