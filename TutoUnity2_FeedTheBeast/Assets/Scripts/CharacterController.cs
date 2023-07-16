using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    private float horizontalInput;
    private float verticalInput;
    private float speed = 20.0f;
    public float xBoundaryRange = 20.0f;
    public float zBoundaryRange = 10.0f;
    public float zOffsetBoundary = 5.0f;

    public GameObject projectilePrefab;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            var bone = Instantiate(projectilePrefab, transform.position + Vector3.forward, projectilePrefab.transform.rotation);
            bone.GetComponent<DetectCollisions>().scoreboard = GetComponent<ScoreAndLives>();
        }

        if(transform.position.x < -xBoundaryRange)
        {
            transform.position = new Vector3(-xBoundaryRange + 0.1f, transform.position.y, transform.position.z);
        }else if (transform.position.x > xBoundaryRange)
        {
            transform.position = new Vector3(xBoundaryRange - 0.1f, transform.position.y, transform.position.z);
        }else if(transform.position.z < -zBoundaryRange - zOffsetBoundary)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -zBoundaryRange - zOffsetBoundary + 0.1f);
        }
        else if (transform.position.z > zBoundaryRange - zOffsetBoundary)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, zBoundaryRange - zOffsetBoundary - 0.1f );
        }
        else

            horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * speed * horizontalInput * Time.deltaTime);

        verticalInput = Input.GetAxis("Vertical");
        transform.Translate(Vector3.forward * speed * verticalInput * Time.deltaTime);
    }
}
