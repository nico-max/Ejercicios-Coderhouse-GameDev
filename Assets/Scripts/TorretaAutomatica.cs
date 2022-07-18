using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorretaAutomatica : MonoBehaviour
{
    private enum TipoEnemigo
    {
        Apuntado,
        Disparando,
        Calentando
    }


    [SerializeField]
    private TipoEnemigo enemyType;

    [SerializeField]
    private Animator anim;

    public GameObject Jugador;
    public GameObject InstanciaBala;

    public Transform cilindro;

    public float speedToLook;


    float counterDisparos;
    float counterCooldown;
    float counterCalentamiento;


    float cooldownDisparo;
    float tiempoCalentamiento;
    float cadenciaDisparo;

    int rafagas = 10;
    int disparosRestantes;

    private void Start()
    {
        //anim = GetComponent<Animator>();

        enemyType = TipoEnemigo.Calentando;

        cooldownDisparo = 5f;
        tiempoCalentamiento = 3f;
        cadenciaDisparo = 0.5f;

    }

    void Update()
    {
        switch (enemyType)
        {
            case TipoEnemigo.Apuntado:
                ModoApuntado();
                break;

            case TipoEnemigo.Disparando:
                ModoDisparar();
                break;

            case TipoEnemigo.Calentando:
                ModoCalentar();
                break;
        }
    }

    void ModoApuntado()
    {
        ApuntarJugador();

        anim.SetBool("Disparando", false);

        if(counterCooldown<=0)
        {
            enemyType = TipoEnemigo.Calentando;
            reiniciarContadorCalentamiento();
        }
        else
        {
            counterCooldown  -= Time.deltaTime;
        }
    }

    void ModoCalentar()
    {
        ApuntarJugador();

        anim.SetBool("Disparando", true);

        if(counterCalentamiento<=0)
        {
            enemyType = TipoEnemigo.Disparando;
            reiniciarContadorDisparos();
            recargarArma();
        }
        else
        {
            counterCalentamiento -= Time.deltaTime;
        }
    }

    void ModoDisparar()
    {
        ApuntarJugador();

        anim.SetBool("Disparando", true);
        
        Disparos();
    }

    void Disparos()
    {
        counterDisparos -= Time.deltaTime;

        if ((disparosRestantes > 0) && (counterDisparos <= 0))
        {
            Disparo();
            reiniciarContadorDisparos();
            disparosRestantes--;
        }
        else if(disparosRestantes<=0)
        {
            enemyType = TipoEnemigo.Apuntado;
            reiniciarContadorCooldown();
        }

    }

    void reiniciarContadorDisparos()
    {
        counterDisparos = cadenciaDisparo;
    }

    void reiniciarContadorCooldown()
    {
        counterCooldown = cooldownDisparo;
    }

    void reiniciarContadorCalentamiento()
    {
        counterCalentamiento = tiempoCalentamiento;
    }

    void Disparo()
    {
        Instantiate(InstanciaBala, cilindro.position, transform.rotation);
    }

    void recargarArma()
    {
        disparosRestantes = rafagas;
    }

    void ApuntarJugador()
    {
        Quaternion objetivo = Quaternion.LookRotation((Jugador.transform.position - transform.position));
        transform.rotation = Quaternion.Lerp(transform.rotation, objetivo, speedToLook * Time.deltaTime);

        //torreta.LookAt(Jugador.transform);
    }
}
