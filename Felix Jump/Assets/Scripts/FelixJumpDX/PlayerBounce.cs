using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerBounce : MonoBehaviour
{
    public PlayerInput playerInput;
    public InputAction moveAction;
    public float minBounceForce = 1f;
    public float maxBounceForce = 20f;
    public float bounceForce = 10f;
    private Rigidbody rb;

    private void Start()
    {
        playerInput = GetComponent<PlayerInput>();
        rb = GetComponent<Rigidbody>();
        moveAction = playerInput.actions.FindAction("Move");

        if (rb == null)
        {
            Debug.LogError("No se encontró un Rigidbody en el objeto jugador.");
        }
    }

    private void Update()
    {
        var vec = moveAction.ReadValue<Vector2>();
        if (vec.y > Single.Epsilon)
            Debug.Log(vec.ToString());
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.GetContact(0).point.y < transform.position.y)
        {

            rb.velocity = Vector3.zero;
            rb.AddForce(Vector3.up * bounceForce, ForceMode.Impulse);
        }
    }

    void OnMove(InputValue value)
    {
        bounceForce = Mathf.Lerp(minBounceForce, maxBounceForce, (value.Get<Vector2>().y+1)/2);

    }
}