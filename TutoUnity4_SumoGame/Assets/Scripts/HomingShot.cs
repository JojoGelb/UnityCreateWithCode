using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingShot : MonoBehaviour
{
    public float speed;
    public float strength = 10.0f;
    private Rigidbody homingShotRb;
    private GameObject enemy;

    // Start is called before the first frame update
    void Start()
    {
        homingShotRb = GetComponent<Rigidbody>();
        enemy = GameObject.FindGameObjectWithTag("Enemy");
    }

    // Update is called once per frame
    void Update()
    {

        if(enemy == null)
        {
            enemy = GameObject.FindGameObjectWithTag("Enemy");
            return;
        }

        Vector3 lookDirection = new Vector3(enemy.transform.position.x - transform.position.x,0, enemy.transform.position.z - transform.position.z).normalized;
        homingShotRb.AddForce(lookDirection * speed * Time.deltaTime);

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Rigidbody enemyRb = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 oppositeMissile = (collision.gameObject.transform.position - transform.position);
            enemyRb.AddForce(oppositeMissile * strength, ForceMode.Impulse);
            Destroy(gameObject);
        }
    }
}
