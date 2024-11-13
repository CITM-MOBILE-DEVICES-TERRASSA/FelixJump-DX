using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using TMPro;

[RequireComponent(typeof(Rigidbody))]
public class BallController : MonoBehaviour
{
    public float bounceForce = 3f;
    private float originalBounceForce;
    private Rigidbody rb;
    private float lastTapTime = 0f;
    private float doubleTapDelay = 0.3f; // Time window for double-tap

    public GameObject ballPrefab;

    private bool bonusScoreAdded = false; // Add this line

    PlataformaController plataformaController;
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

    //Al derectar choques
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Plataforma"))
        {
            rb.AddForce(Vector3.up * bounceForce, ForceMode.Impulse);
            bounceForce = originalBounceForce; // Reset bounce force after collision
        }

        if (collision.gameObject.CompareTag("Trampa"))
        {
            transform.position = new Vector3(0, 0.4f, -0.7f);
        }
    }

    //Al detectar que esta dentro
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Meta") && !bonusScoreAdded)
        {
            if (CylinderController.instance)
            {
                Debug.Log("Nivel Completado");
                CylinderController.instance.endPanel.gameObject.SetActive(true);

                // Stop the timer immediately
                PlataformaController.instance.timerRunning = false;

                // Handle level completion
                string currentScene = UnityEngine.SceneManagement.SceneManager.GetActiveScene().name;
                Score.Instance.HandleLevelCompletion(currentScene, PlataformaController.instance.countdownTime);

                bonusScoreAdded = true;
            }
        }
    }
}