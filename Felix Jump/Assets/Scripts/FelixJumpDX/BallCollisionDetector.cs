using UnityEngine;

public class BallCollisionDetector : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Plataforma"))
        {
            Transform platformTransform = collision.gameObject.transform;

            CameraFollower cameraFollower = Camera.main.GetComponent<CameraFollower>();
            if (cameraFollower != null)
            {
                cameraFollower.SetTarget(platformTransform);
            }
        }
    }
}
