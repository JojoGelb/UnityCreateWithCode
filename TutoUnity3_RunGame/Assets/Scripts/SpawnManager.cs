using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] obstaclePrefab;
    private Vector3 spawnPos = new Vector3(25, 0, 0);

    private float repeatRate = 2;

    public PlayerController playerControllerScript;

    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
        Invoke("spawnObstacle", 2);
    }

    void spawnObstacle()
    {

        if(playerControllerScript.transform.position.x < 0)
        {
            Invoke("spawnObstacle", repeatRate);
            return;
        }

        if(playerControllerScript.gameOver == false)
        {
            int randomObstacleIndex = Random.Range(0, obstaclePrefab.Length);
            Instantiate(obstaclePrefab[randomObstacleIndex], spawnPos, obstaclePrefab[randomObstacleIndex].transform.rotation);
        }

        if (playerControllerScript.sprinting)
        {
            Invoke("spawnObstacle", repeatRate/2);
        }
        else
        {
            Invoke("spawnObstacle", repeatRate);
        }



        

    }
}
