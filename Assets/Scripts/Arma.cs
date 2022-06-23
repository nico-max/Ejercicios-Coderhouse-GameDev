using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arma : MonoBehaviour
{
    public GameObject instanciaBala;
    public Transform cilindro;

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
    }

    void Disparo()
    {
        Instantiate(instanciaBala, cilindro.position, transform.rotation);
    }
}
