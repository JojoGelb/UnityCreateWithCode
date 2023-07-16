using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBound : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {

        if(transform.position.z > 50)
        {
            Destroy(gameObject);
        }
        else if(transform.position.z < -50)
        {
            Debug.Log("Game Over");
            Destroy(gameObject);
        }


    }
}
