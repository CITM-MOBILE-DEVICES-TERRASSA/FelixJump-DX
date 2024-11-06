using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformaController : MonoBehaviour
{

    public GameObject plataforma1Hole;
    public GameObject plataforma2Hole;

    private GameObject plataformaToSpawn;

    public int numeroPlataforma = 0;


    public float distanciaSpawn = 5f;

    public float startingY = 0;

    private float lastOrientationY = 0;
   
    // Start is called before the first frame update
    void Start()
    {
        
        for(int i = 0; i<numeroPlataforma; i++)
        {
            plataformaToSpawn = (Random.Range(0, 2) == 0) ? plataforma1Hole : plataforma2Hole;

            float rotationY = Random.Range(45, 315);
            while( Mathf.Abs(rotationY - lastOrientationY) < 45)
            {
                rotationY = Random.Range(45, 315);
            }
            lastOrientationY = rotationY;

            Instantiate(plataformaToSpawn, new Vector3(0, startingY + (distanciaSpawn * (i+1)), 0), Quaternion.Euler(0, rotationY, 0), CylinderController.instance.cylinder.transform);
        }



    }

    // Update is called once per frame
    void Update()
    {
        //contador += Time.deltaTime;
        //if (contador > 5)
        //{
        //    GameObject plataforma = Instantiate(plataforma1Hole, CylinderController.instance.cylinder.transform);
        //    plataformas.Add(plataforma.transform);
        //    contador = 0;
        //}


        //foreach(Transform plataforma in plataformas)
        //{
        //    plataforma.transform.position = new Vector3(0, plataforma.transform.position.y - (movementSpeed * Time.deltaTime), 0);
        //}
    }
}
