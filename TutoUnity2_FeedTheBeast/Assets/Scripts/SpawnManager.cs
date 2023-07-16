using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] animalPrefabs;
    public float spawnRadius = 20;
    public float spawnZ = 10f;
    public float spawnX = 20f;
    // Update is called once per frame

    void Start()
    {
        InvokeRepeating("spawnRandomAnimal", 2, 1.5f);
    }

    void spawnRandomAnimal()
    {
        int animalIndex = Random.Range(0, animalPrefabs.Length);
        Vector3 randomPositon = Vector3.zero;
        Quaternion rotation = animalPrefabs[animalIndex].transform.rotation;
        float spawnPoint;

        switch ((int)Random.Range(0, 4))
        {
            case 0: //Bottom
                spawnPoint = Random.Range(-spawnX, spawnX);
                randomPositon = new Vector3(spawnPoint, 0, -spawnRadius);
                break;
            case 1: //Top
                spawnPoint = Random.Range(-spawnX, spawnX);
                randomPositon = new Vector3(spawnPoint, 0, spawnRadius);
                rotation = Quaternion.Euler(0, 0, 0);
                break;
            case 2: //Left
                spawnPoint = Random.Range(-spawnZ, spawnZ);
                randomPositon = new Vector3(spawnRadius, 0, spawnPoint);
                rotation = Quaternion.Euler(0, 90, 0);
                break;
            case 3: //Right
                spawnPoint = Random.Range(-spawnZ, spawnZ);
                randomPositon = new Vector3(-spawnRadius, 0, spawnPoint);
                rotation = Quaternion.Euler(0, -90, 0);
                break;
        }
       
        
        Instantiate(animalPrefabs[animalIndex], randomPositon, animalPrefabs[animalIndex].transform.rotation * rotation);
    }
}
