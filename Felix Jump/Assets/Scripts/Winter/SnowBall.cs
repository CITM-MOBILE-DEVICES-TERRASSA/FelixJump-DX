using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowBall : MonoBehaviour
{
    public float growthSpeed = 0.1f; // Velocidad de crecimiento de la bola de nieve
    public Vector3 maxScale = new Vector3(0.5f, 0.5f, 0.5f); // Tamaño máximo de la bola de nieve
    public GameObject ball; // Referencia a la pelota
    public float thresholdDistance = 2.0f; // Distancia a la que empieza a crecer la bola de nieve
    public float rotationSpeed = 2.0f; // Velocidad de rotación en círculos
    public float radius = 3.0f; // Radio del círculo

    // Límite máximo para la posición de la bola de nieve en el eje X y Z
    public float positionLimit = 0.5f;

    void Update()
    {
        //MoveInCircles();
        transform.Rotate(0, rotationSpeed * Time.deltaTime, 0);
        // Calcular la distancia entre la bola de nieve y la pelota
        float distanceToBall = Vector3.Distance(transform.position, ball.transform.position);

        // Si la distancia es menor que el umbral, y la bola de nieve no ha alcanzado el tamaño máximo
        if (distanceToBall < thresholdDistance)
        {
            if (transform.localScale.x < maxScale.x && transform.localScale.y < maxScale.y && transform.localScale.z < maxScale.z)
            {
                // Aumenta el tamaño de la bola de nieve
                transform.localScale += Vector3.one * growthSpeed * Time.deltaTime;
            }
        }
    }

    void MoveInCircles()
    {
        // Movimiento circular en el plano XZ, con el centro en (0, 0, 0)
        float x = Mathf.Cos(Time.time * rotationSpeed) * radius;
        float z = Mathf.Sin(Time.time * rotationSpeed) * radius;

        // Asegurarnos de que la posición no supere el valor de 1.5 en los ejes X y Z
        x = Mathf.Clamp(x, -positionLimit, positionLimit);
        z = Mathf.Clamp(z, -positionLimit, positionLimit);

        // Establecer la nueva posición, manteniendo la componente Y constante (sin movimiento en Y)
        transform.position = new Vector3(x, transform.position.y, z);
    }
}
