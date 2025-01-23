using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private PlatformRotationController _pc;
    private PlayerBounce _pb;
    
    // Start is called before the first frame update
    void Start()
    {
        _pc = FindObjectOfType<PlatformRotationController>();
        _pb = FindObjectOfType<PlayerBounce>();
    }

    
    void OnMove(InputValue value)
    {
        Vector2 input = value.Get<Vector2>();
        input.x = (input.x + 1) / 2;
        input.y = (input.y + 1) / 2;

        _pc.SetRotationSpeed(input.x);
        _pb.SetBounceForce(input.y);
    }
    
}
