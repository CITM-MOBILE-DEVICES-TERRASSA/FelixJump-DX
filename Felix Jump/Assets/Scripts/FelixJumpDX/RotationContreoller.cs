using UnityEngine;
using UnityEngine.UI;

public class PlatformRotationController : MonoBehaviour
{
    public Slider rotationSlider;
    public float minRotation = -90f;
    public float maxRotation = 90f;

    private void Update()
    {
        if (rotationSlider != null)
        {
            float rotationAngle = Mathf.Lerp(minRotation, maxRotation, rotationSlider.value);

            transform.rotation = Quaternion.Euler(0f, rotationAngle, 0f);
        }
        else
        {
            Debug.LogWarning("El slider no está asignado en el inspector.");
        }
    }
}
