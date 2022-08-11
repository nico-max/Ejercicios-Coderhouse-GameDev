using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoTorreta : Enemigo
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

    float counterDisparos;
    float counterCooldown;
    float counterCalentamiento;

    float cooldownDisparo;
    float tiempoCalentamiento;
    float cadenciaDisparo;

    int rafagas = 10;
    int disparosRestantes;

    void Start()
    {
        enemyType = TipoEnemigo.Calentando;

        cooldownDisparo = 5f;
        tiempoCalentamiento = 3f;
        cadenciaDisparo = 0.5f;
    }

    // Update is called once per frame
    void Update()
    {
        ApuntarJugador();

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

        anim.SetBool("Disparando", false);

        if (counterCooldown <= 0)
        {
            enemyType = TipoEnemigo.Calentando;
            reiniciarContadorCalentamiento();
        }
        else
        {
            counterCooldown -= Time.deltaTime;
        }
    }

    void ModoCalentar()
    {

        anim.SetBool("Disparando", true);

        if (counterCalentamiento <= 0)
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
        else if (disparosRestantes <= 0)
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
}
