using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerBounce : MonoBehaviour
{
    public float minBounceForce = 1f;
    public float maxBounceForce = 20f;
    public float bounceForce = 10f;
    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();

        if (rb == null)
        {
            Debug.LogError("No se encontró un Rigidbody en el objeto jugador.");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.GetContact(0).point.y < transform.position.y)
        {
            FindObjectOfType<FJDXScore>().OnLandOnPlatform(collision.gameObject);
            if (FJDXScore.GoalReached)
            {
                bounceForce = maxBounceForce * 3;
                rb.useGravity = false;
            }
            rb.velocity = Vector3.zero;
            rb.AddForce(Vector3.up * bounceForce, ForceMode.Impulse);
        }
    }

    // Using a value between 0 and 1 sets the bounce force to use on the next bounce
    public void SetBounceForce(float rangeValue)
    {
        bounceForce = Mathf.Lerp(minBounceForce, maxBounceForce, rangeValue);
    }
}