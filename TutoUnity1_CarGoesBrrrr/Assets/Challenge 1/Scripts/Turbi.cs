using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turbi : MonoBehaviour
{
    private float rotationSpeed = 5000f;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.forward * Time.deltaTime * rotationSpeed);
    }
}
