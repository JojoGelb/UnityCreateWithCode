using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{

    public GameObject player;
    private Vector3 backViewOffset = new Vector3(0, 5, -7);
    public Vector3 frontViewOffset = new Vector3(0, 2, 0.3f);
    private bool frontView = false;


    // Update is called once per frame
    void LateUpdate()
    {

        if (Input.GetKeyDown("r"))
        {
            frontView = !frontView;
        }

        if (frontView)
        {
            transform.position = player.transform.position + frontViewOffset;
            transform.rotation = player.transform.rotation;
        }
        else
        {
            transform.position = player.transform.position + backViewOffset;
            transform.rotation = Quaternion.identity;
            transform.Rotate(18, 0, 0);
        }

        

    }
}
