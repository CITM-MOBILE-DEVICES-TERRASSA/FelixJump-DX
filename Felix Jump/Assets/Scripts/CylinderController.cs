using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CylinderController : MonoBehaviour
{

    public Slider cylinderSlider;
    public Transform Cylinder;
    public float rotationSpeed = 10f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Cylinder.Rotate(new Vector3(0, -cylinderSlider.value * rotationSpeed * Time.deltaTime, 0));
    }
}
