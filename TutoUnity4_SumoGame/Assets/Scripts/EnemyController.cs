using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed;
    protected Rigidbody enemyRb;
    protected GameObject player;
    // Start is called before the first frame update
    virtual protected void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    virtual protected void Update()
    {
        Vector3 lookDirection = (player.transform.position - transform.position).normalized;
        enemyRb.AddForce(lookDirection * speed * Time.deltaTime);

        if(transform.position.y < -10)
        {
            Destroy(gameObject);
        }

    }
}
