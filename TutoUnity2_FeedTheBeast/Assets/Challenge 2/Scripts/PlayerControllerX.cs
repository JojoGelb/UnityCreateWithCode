using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public GameObject dogPrefab;
    public float coolDownTime = 2f;
    private bool isInCoolDown;

    // Update is called once per frame
    void Update()
    {
        // On spacebar press, send dog
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!isInCoolDown)
            {
                Instantiate(dogPrefab, transform.position, dogPrefab.transform.rotation);
                isInCoolDown = true;
                Invoke("enableCapacity", coolDownTime);
            }
        }
    }

    void enableCapacity()
    {
        isInCoolDown = false;
    }
}
