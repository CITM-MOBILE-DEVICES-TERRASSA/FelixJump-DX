using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformaController : MonoBehaviour
{

    [Header("GameObjects")]
    public GameObject metaFinal;
    public GameObject plataforma1Hole;
    public GameObject plataforma2Hole;
    public GameObject ballPrefab; // Add a reference to the ball prefab
    public GameObject plataformaPinchos1Hole;
    public GameObject plataformaPinchos2Hole;

    private GameObject plataformaToSpawn;

    [Header("Generador")]
    public int numeroPlataforma = 0;
    public float distanciaSpawn = 5f;
    public float startingY = 0;

    private float lastOrientationY = 0;

    [Header("Obstaculos")]

    //public GameObject pinchosGameObject;
    public GameObject leafSpawner;
    public GameObject redGameObject;
    public GameObject bolaNieveGameObject;

    public bool aparecerHojas;
    public bool aparecerRedes;
    public bool aparecerBolasNieve;
   
    // Start is called before the first frame update
    void Start()
    {
        //Plataformas
        for (int i = 0; i < numeroPlataforma; i++)
        {
            // Elegir plataforma al azar entre las cuatro opciones
            int plataformaAleatoria = Random.Range(0, 4);
            if (plataformaAleatoria == 0)
            {
                plataformaToSpawn = plataforma1Hole;
            }
            else if (plataformaAleatoria == 1)
            {
                plataformaToSpawn = plataforma2Hole;
            }
            else if (plataformaAleatoria == 2)
            {
                plataformaToSpawn = plataformaPinchos1Hole;
            }
            else
            {
                plataformaToSpawn = plataformaPinchos2Hole;
            }

            // Asignar rotaci�n aleatoria manteniendo una diferencia m�nima de 45 grados
            float rotationY = Random.Range(45, 315);
            while (Mathf.Abs(rotationY - lastOrientationY) < 45)
            {
                rotationY = Random.Range(45, 315);
            }
            lastOrientationY = rotationY;

            Instantiate(plataformaToSpawn, new Vector3(0, startingY + (distanciaSpawn * (i + 1)), 0), Quaternion.Euler(0, rotationY, 0), CylinderController.instance.cylinder.transform);
        }

        if (aparecerHojas)
        {
            Instantiate(leafSpawner, new Vector3(0, startingY + (distanciaSpawn * (numeroPlataforma)), 0), Quaternion.identity, CylinderController.instance.cylinder.transform);
        }

        Instantiate(metaFinal, new Vector3(0, startingY + (distanciaSpawn * (numeroPlataforma + 1)), 0), Quaternion.identity, CylinderController.instance.cylinder.transform);

        


        //Pelota
        GameObject ball = Instantiate(ballPrefab, new Vector3(0, 0.4f, -0.7f), Quaternion.identity);
        Rigidbody rb = ball.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Aqu� puedes a�adir l�gica adicional si es necesario.
    }
}
