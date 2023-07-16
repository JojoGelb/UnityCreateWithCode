using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    private float speed = 30;
    private float leftBound = -15;
    private PlayerController playerControllerScript;

    private void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {

        if(playerControllerScript.transform.position.x < 0)
        {
            return;
        }

        if(playerControllerScript.gameOver == false)
        {
            float calcSpeed = speed;
            if (playerControllerScript.sprinting)
            {
                calcSpeed += 15;
            }
            transform.Translate(Vector3.left * Time.deltaTime * calcSpeed);
        }

        if(transform.position.x < leftBound && gameObject.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
        }
    }
}
