using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager _instance;

    public Image barraVida;
    public Text cargador;
    public Image tiempoRecarga;

    private void Awake()
    {
        if(UIManager._instance == null)
        {
            UIManager._instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        cargador.text = "6";
        tiempoRecarga.fillAmount = 0;
    }

    private void Update()
    {
        
    }

    public void DisparoJugador(int disparosRestantes)
    {
        cargador.text = disparosRestantes.ToString();
    }

    public void actualizarVida(float vidaActual)
    {
        barraVida.fillAmount = vidaActual / 100f;
    }

    public void IniciarRecarga()
    {
        tiempoRecarga.fillAmount = 1;
    }

    public void actualizarTiempoRecarga(float tiempoRestante, float tiempoTotal)
    {
        tiempoRecarga.fillAmount = tiempoRestante/ tiempoTotal;
    }
}
