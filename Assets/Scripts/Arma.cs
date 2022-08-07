using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arma : MonoBehaviour
{
    public GameObject instanciaBala;
    public Transform cilindro;

    public float fireRate;
    public float reloadTime;

    public int disparosRestantes;
    public float counter;

    bool recargando;

    // Start is called before the first frame update
    void Start()
    {
        recargando = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            //Transform cilindro = transform.GetChild(0).gameObject.transform;
            //instanciaBala.GetComponent<Bala>().setDirection(cilindro.transform);

            Disparo();
        }
        else if(Input.GetKeyDown(KeyCode.R))
        {
            if(disparosRestantes < 6)
            {
                counter = reloadTime;
                recargando = true;
                UIManager._instance.IniciarRecarga();
            }
        }

        if (recargando)
        {
            UIManager._instance.actualizarTiempoRecarga(counter, reloadTime);
        }

        if (counter > 0)
        {
            counter -= Time.deltaTime;
        }
        else if(counter <= 0 && recargando)
        {
            Recargar();
            recargando = false;
        }


        UIManager._instance.DisparoJugador(disparosRestantes);

        

        /**
         * 
         * @Deprecated
         * Este codigo era para un ejercicio en el que se disparaba automáticamente, pero quedo en desuso
         * 
        else if (Input.GetKeyDown(KeyCode.J))
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
        **/
    }

    // @Deprecated
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
        if ((disparosRestantes > 0) && (counter <= 0))
        {
            Instantiate(instanciaBala, cilindro.position, transform.rotation);
            reiniciarContador();
            disparosRestantes--;
            

            if (disparosRestantes == 0)
            {
                counter = reloadTime;
                recargando = true;
                UIManager._instance.IniciarRecarga();
            }
        }
        
    }

    void Recargar()
    {
        disparosRestantes = 6;
    }
}
