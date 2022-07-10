using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jugador : MonoBehaviour
{
    public float speed;
    public float rotationSpeed;

    public GameObject camarasFijas;
    public GameObject camaraJugador;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Movimiento();
        controlRotationSpeed();

        if (Input.GetKeyDown(KeyCode.C))
        {
            ToggleCamera();
        }

    }

    void controlRotationSpeed()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = 7;
        }
        else
        {
            speed = 2;
        }
    }

    void ToggleCamera()
    {
        if(camaraJugador.activeInHierarchy)
        {
            camaraJugador.SetActive(false);
            camarasFijas.SetActive(true);
        }
        else
        {
            camaraJugador.SetActive(true);
            camarasFijas.SetActive(false);
        }
    }

    void Movimiento()
    {
        /**
        float hor = Input.GetAxis("Horizontal");
        float ver = Input.GetAxis("Vertical");

        transform.Translate(new Vector3(hor, 0, ver) * speed * Time.deltaTime);
        */

        float ver = Input.GetAxis("Vertical");
        transform.Translate(new Vector3(0, 0, ver) * speed * Time.deltaTime);

        float hor = Input.GetAxisRaw("Horizontal");
        transform.Rotate(new Vector3(0, hor, 0) * rotationSpeed * Time.deltaTime);
        
    }

    void Rotacion()
    {
        //@deprecated

        /**
         * Esta rotacion esta igualmente implementada con las siguientes lineas:
         * float hor = Input.GetAxisRaw("Horizontal");
         * transform.Rotate(new Vector3(0, hor, 0) * rotationSpeed * Time.deltaTime);
         */

        if (Input.GetKey(KeyCode.E))
        {
            transform.Rotate(new Vector3(0, 1, 0), speed);
        }
        else if (Input.GetKey(KeyCode.Q))
        {
            transform.Rotate(new Vector3(0, -1, 0), speed);
        }
    }
}
