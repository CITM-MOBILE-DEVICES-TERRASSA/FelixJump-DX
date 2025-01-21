using UnityEngine;

public class PlayerBounce : MonoBehaviour
{
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
        if (collision.contacts.Length > 0)
        {
            Vector3 surfaceNormal = collision.contacts[0].normal;

            rb.velocity = Vector3.zero; 
            rb.AddForce(surfaceNormal * bounceForce, ForceMode.Impulse);
        }
    }
}