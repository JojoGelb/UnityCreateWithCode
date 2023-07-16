using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossControllerScript : EnemyController
{

    private float cooldown = 5.0f;
    public GameObject[] minionsPrefab;
    private bool flyingAttack = false;
    public float shockWaveStrenght = 5.0f;


    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();

        InvokeRepeating("strongAttack",cooldown, cooldown);
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();

        if (flyingAttack && transform.position.y > 3)
        {
            enemyRb.velocity = new Vector3(0, -10, 0);

        }
    }

    private void strongAttack()
    {
        int index = Random.Range(0, 2);

        switch (index)
        {
            case 0:
                int minionIndex = Random.Range(0, minionsPrefab.Length);
                Instantiate(minionsPrefab[minionIndex], transform.position + new Vector3(0, 4, 0), minionsPrefab[minionIndex].transform.rotation);
                break;
            case 1:
                enemyRb.velocity = new Vector3(0, 7, 0);
                flyingAttack = true;
                break;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(flyingAttack && collision.gameObject.CompareTag("Ground"))
        {
            flyingAttack = false;
            Rigidbody playerRb =  GameObject.Find("Player").GetComponent<Rigidbody>();
            Vector3 opposite = (playerRb.gameObject.transform.position - transform.position);

            playerRb.AddForce(opposite * shockWaveStrenght, ForceMode.Impulse);
        }
    }

    void OnDestroy()
    {
        foreach(var obj in GameObject.FindGameObjectsWithTag("Enemy"))
        {
            Destroy(obj);
        }
    }
}
