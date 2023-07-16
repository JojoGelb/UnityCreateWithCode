using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] enemyPrefab;
    public GameObject[] powerupPrefab;
    public GameObject bossPrefab;

    private float spawnRange = 9;
    public int waveNumber = 1;

    public int enemyCount = 0;
    // Start is called before the first frame update
    private void Update()
    {
        enemyCount = FindObjectsOfType<EnemyController>().Length;
        if(enemyCount == 0)
        {
            int index = Random.Range(0, enemyPrefab.Length);
            Instantiate(powerupPrefab[index], generateSpawnPoint(), powerupPrefab[index].transform.rotation);

            if(waveNumber%5 == 1 && waveNumber != 1)
            {
                spawnBossWave();
            }
            else
            {
                spawnEnemyWave(waveNumber);
            }


            waveNumber++;
        }
    }

    void spawnBossWave()
    {
        Instantiate(bossPrefab, generateSpawnPoint(), bossPrefab.transform.rotation);
    }

    void spawnEnemyWave(int n)
    {
        for(int i = 0; i<n; i++)
        {
            spawnEnemy();
        }
    }

    void spawnEnemy()
    {
        int index = Random.Range(0, enemyPrefab.Length);
        Instantiate(enemyPrefab[index], generateSpawnPoint(), enemyPrefab[index].transform.rotation);
    }

    Vector3 generateSpawnPoint()
    {
        float spawnPosX = Random.Range(-spawnRange, spawnRange);
        float spawnPosZ = Random.Range(-spawnRange, spawnRange);
        return new Vector3(spawnPosX, 0, spawnPosZ);
    }
}
