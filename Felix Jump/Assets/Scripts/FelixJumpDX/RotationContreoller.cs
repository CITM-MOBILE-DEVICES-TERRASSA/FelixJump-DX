using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class PlatformRotationController : MonoBehaviour
{
    [FormerlySerializedAs("maxRotation")] public float maxRotationSpeed = 90f;
    public float rotationSpeed = 0f;
    

    private void Update()
    {
        float rotationAngle = transform.rotation.eulerAngles.y;

        transform.rotation = Quaternion.Euler(0f, rotationAngle+rotationSpeed, 0f);
    }

    public void SetRotationSpeed(float rangeValue)
    {
        rotationSpeed = Mathf.Lerp(-maxRotationSpeed, maxRotationSpeed, rangeValue);
    }
}
