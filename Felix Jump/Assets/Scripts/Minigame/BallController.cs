using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class BallController : MonoBehaviour
{
    public float bounceForce = 3f;
    private float originalBounceForce;
    private Rigidbody rb;
    private float lastTapTime = 0f;
    private float doubleTapDelay = 0.3f; // Time window for double-tap

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        originalBounceForce = bounceForce;
    }

    void Update()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began) // Check for touch input
        {
            if (Time.time - lastTapTime < doubleTapDelay)
            {
                bounceForce = originalBounceForce * 2;
            }
            lastTapTime = Time.time;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Plataforma"))
        {
            rb.AddForce(Vector3.up * bounceForce, ForceMode.Impulse);
            bounceForce = originalBounceForce; // Reset bounce force after collision
        }
    }
}