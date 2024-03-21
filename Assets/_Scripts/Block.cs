using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class Block : MonoBehaviour
{
    public int endurance;
    public UnityEvent aumentarPuntaje;

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ball") 
        {
            // Función para rebotar bola
            Bounce(collision);
        }
    }

    public virtual void Bounce(Collision collision)
    {
        Vector3 direccion = collision.contacts[0].point - transform.position;
        direccion = direccion.normalized;
        collision.rigidbody.velocity = collision.gameObject.GetComponent<Ball>().speed * direccion;
        endurance--;
    }

    // Start is called before the first frame update
    void Start()
    {
        endurance = 2;
    }

    // Update is called once per frame
    void Update()
    {
        if (endurance <= 0) 
        {
            aumentarPuntaje.Invoke();
            Destroy(this.gameObject);
        }
    } 

    public virtual void BlockDestruction()
    {
        
    }
}
