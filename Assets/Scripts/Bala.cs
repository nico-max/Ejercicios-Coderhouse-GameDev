using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala : MonoBehaviour
{
    public float speed;
    public Vector3 direction;
    public int damage;

    public float lifeTime;

    public bool crecer;
    
    void Start()
    {

    }

    void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime);

        Destroy(gameObject, lifeTime);

        if(crecer)
        {
            if(Input.GetKeyDown(KeyCode.Space))
            {
                Debug.Log("crecio");
                transform.localScale *= 2;
            }
        }
    }

}
