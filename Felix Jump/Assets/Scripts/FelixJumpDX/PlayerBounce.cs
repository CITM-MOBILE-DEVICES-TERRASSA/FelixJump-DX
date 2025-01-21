using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerBounce : MonoBehaviour
{
    public float minBounceForce = 1f;
    public float maxBounceForce = 20f;
    public float bounceForce = 10f;
    private Rigidbody rb;
    InputAction moveAction;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        moveAction = InputSystem.actions.FindAction("Move");

        if (rb == null)
        {
            Debug.LogError("No se encontró un Rigidbody en el objeto jugador.");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.contacts.Length > 0)
        {
            bounceForce = Mathf.Lerp(minBounceForce,maxBounceForce, moveAction.ReadValue<float>());

            rb.velocity = Vector3.zero; 
            rb.AddForce(Vector3.up * bounceForce, ForceMode.Impulse);
        }
    }
}