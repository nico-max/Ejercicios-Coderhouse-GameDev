using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala : MonoBehaviour
{
    public float speed;
    public Vector3 direction;
    public int damage;
    
    void Start()
    {
        
    }

    void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime);
    }

}
