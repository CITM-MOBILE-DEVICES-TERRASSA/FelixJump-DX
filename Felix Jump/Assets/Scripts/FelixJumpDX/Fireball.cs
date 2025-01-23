using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    [Min(Single.Epsilon)] public float impulsePower;
    [Min(Single.Epsilon)] public float rotationPower;
    
    private void Start()
    {
        var rb = GetComponent<Rigidbody>();
        
        rb.AddForce(Vector3.up * impulsePower, ForceMode.Impulse);
        rb.AddTorque(Vector3.up * rotationPower, ForceMode.Impulse);
    }

    private void OnCollisionEnter(Collision other)
    {
        // Previene la autodestruccion por colision con objetos de la misma plataforma
        if (transform.IsChildOf(other.transform)) return;
        
        StartCoroutine(SelfDestruct());
    }

    // Self destructs on next frame
    IEnumerator SelfDestruct()
    {
        yield return null;
        
        Destroy(gameObject);
    }
}
