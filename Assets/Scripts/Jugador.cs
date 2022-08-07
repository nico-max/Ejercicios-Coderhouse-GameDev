using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jugador : MonoBehaviour
{
    public float speed;
    public float rotationSpeed;

    public GameObject camarasFijas;
    public GameObject camaraJugador;

    [SerializeField]
    private int life;

    public Transform[] puntosObjetivo;
    public bool sentidoHorario;
    [SerializeField]
    public Queue<Vector3> puntosQueue;
    public Vector3 objetivoActual;

    public Vector3 spawn;


    Dictionary<int, GameObject> inventory;

    // Start is called before the first frame update
    void Start()
    {
        life = 100;
        sentidoHorario = true;
        puntosQueue = new Queue<Vector3>();
        spawn = transform.position;

        GameObject sword = transform.GetChild(1).gameObject;
        GameObject gun = transform.GetChild(0).gameObject;

        inventory = new Dictionary<int, GameObject>();
        inventory.Add(1, gun);
        inventory.Add(2, sword);
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

        if (life <= 0)
        {
            life = 100;
            Respawn();
        }

        if (Input.GetKeyDown(KeyCode.I))
        {
            crearRutina();
        }

        ejecutarRutina();

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            inventory[2].SetActive(false);

            inventory[1].SetActive(true);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            inventory[1].SetActive(false);

            inventory[2].SetActive(true);
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Bala")
        {
            Destroy(other.gameObject);

            int damage = other.gameObject.GetComponent<Bala>().damage;

            life -= damage;

            UIManager._instance.actualizarVida(life);
        }
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Torch")
        {
            if (puntosQueue.Count > 0)
            {
                objetivoActual = puntosQueue.Dequeue();
            }
            else
            {
                objetivoActual = Vector3.zero;
            }

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
        if (camaraJugador.activeInHierarchy)
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

    void Respawn()
    {
        transform.position = spawn;
        UIManager._instance.actualizarVida(life);
    }


    public void crearRutina()
    {

        if (sentidoHorario)
        {
            for (int i = 0; i < puntosObjetivo.Length; i++)
            {
                puntosQueue.Enqueue(puntosObjetivo[i].position);
            }
        }
        else
        {
            for (int i = puntosObjetivo.Length - 1; i >= 0; i--)
            {
                puntosQueue.Enqueue(puntosObjetivo[i].position);
            }
        }

        puntosQueue.Enqueue(spawn);
    }

    public void ejecutarRutina()
    {
        if (objetivoActual != Vector3.zero && transform.position != objetivoActual)
        {
            MoverHaciaObjetivo(objetivoActual);
        }
        else if (puntosQueue.Count > 0)
        {
            objetivoActual = puntosQueue.Dequeue();
        }
        else
        {
            objetivoActual = Vector3.zero;
        }
    }

    void MoverHaciaObjetivo(Vector3 objetivo)
    {
        transform.position = Vector3.MoveTowards(transform.position, objetivo, speed * 2 * Time.deltaTime);

        Vector3 posObjetivo = new Vector3(objetivo.x, 0, objetivo.z);

        Vector3 direction = (posObjetivo - transform.position);

        //Quaternion rot = Quaternion.LookRotation(new Vector3(0, direction.y, direction.z));
        Quaternion rot = Quaternion.LookRotation(direction);

        transform.rotation = new Quaternion(0, rot.y, 0, rot.w);


    }

}
