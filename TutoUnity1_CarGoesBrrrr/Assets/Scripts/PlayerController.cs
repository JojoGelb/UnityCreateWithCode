using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public KeyCode forward;
    public KeyCode backward;
    public KeyCode left;
    public KeyCode right;
    private float speed = 20.0f;
    private float turnSpeed = 40.0f;

    void Update()
    {
        if (Input.GetKey(forward))
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        if (Input.GetKey(backward))
            transform.Translate(Vector3.back * speed * Time.deltaTime);
        if (Input.GetKey(left))
            transform.Rotate(Vector3.down * turnSpeed * Time.deltaTime);
        if (Input.GetKey(right))
            transform.Rotate(Vector3.up * turnSpeed * Time.deltaTime);
    }
}
