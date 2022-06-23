using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ejercicio1 : MonoBehaviour
{
    public Vector3 size;
    public Vector3 direction;
    public float speed;


    void Start()
    {
        size = new Vector3(1, 1, 1);
    }

    // Update is called once per frame
    void Update()
    {
        transform.localScale = size;
        transform.Translate(direction * speed * Time.deltaTime);
    }
}
