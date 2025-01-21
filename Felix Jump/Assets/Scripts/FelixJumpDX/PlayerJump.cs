using UnityEngine;
using UnityEngine.UI; 

public class PlayerButtonJump : MonoBehaviour
{
    public float jumpForce = 10f; 
    public Button jumpButton; 

    private Rigidbody rb;
    private bool isGrounded = false; 

    private void Start()
    {
        rb = GetComponent<Rigidbody>();

        if (rb == null)
        {
            Debug.LogError("No se encontró un Rigidbody en el objeto jugador.");
        }

        if (jumpButton != null)
        {
            jumpButton.onClick.AddListener(PerformJump);
        }
        else
        {
            Debug.LogError("No se asignó un botón de salto en el inspector.");
        }
    }

    private void PerformJump()
    {
        if (isGrounded)
        {
            rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false; 
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.contacts.Length > 0)
        {
            isGrounded = true;
        }
    }
}
