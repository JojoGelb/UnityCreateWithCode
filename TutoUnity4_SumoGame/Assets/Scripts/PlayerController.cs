using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private Rigidbody playerRb;
    public float speed = 5.0f;
    public float powerupStrenght = 15.0f;
    private GameObject focalPoint;
    public float radiusShockWave = 10.0f;
    public float shockWaveStrenght = 7.0f;

    private bool onCooldown = false;
    private float cooldownTime = 5.0f;

    private bool hasPowerup = false;
    private bool startPowerHit = false;

    public GameObject powerupIndicator;
    public GameObject homingShotPrefab;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("FocalPoint");
    }

    // Update is called once per frame
    void Update()
    {
        float forwardInput = Input.GetAxis("Vertical");
        playerRb.AddForce(focalPoint.transform.forward * speed * forwardInput);

        powerupIndicator.transform.position = transform.position + new Vector3(0,-0.5f,0);

        if (Input.GetKeyDown(KeyCode.Space) && !onCooldown)
        {
            GameObject enemy = GameObject.FindGameObjectWithTag("Enemy");
            Vector3 spawnDirection = new Vector3(enemy.transform.position.x - transform.position.x, 0,enemy.transform.position.z - transform.position.z).normalized;
            Instantiate(homingShotPrefab, new Vector3(transform.position.x,0,transform.position.z) + spawnDirection, homingShotPrefab.transform.rotation);
            onCooldown = true;
            StartCoroutine("resetCd");
        }

        if(startPowerHit && transform.position.y > 3)
        {
            playerRb.velocity = new Vector3(0, -10, 0);
        }

    }

    IEnumerator resetCd()
    {
        yield return new WaitForSeconds(cooldownTime);
        onCooldown = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Powerup"))
        {
            if (other.name.Contains("Powerup2"))
            {
                startPowerHit = true;
                playerRb.velocity = new Vector3(0, 8, 0);
            }
            else
            {
                powerupIndicator.SetActive(true);
                hasPowerup = true;
                StartCoroutine(PowerupCountdownRoutine());
            }
            Destroy(other.gameObject);
        }
    }

    IEnumerator PowerupCountdownRoutine()
    {
        yield return new WaitForSeconds(7);
        hasPowerup = false;
        powerupIndicator.SetActive(false);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Enemy") && hasPowerup)
        {
            Rigidbody enemyRb = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 oppositePlayer = (collision.gameObject.transform.position - transform.position);

            enemyRb.AddForce(oppositePlayer * powerupStrenght, ForceMode.Impulse);
        
        }

        if (collision.gameObject.CompareTag("Ground") && startPowerHit)
        {
            startPowerHit = false;
            GameObject[] ennemies = GameObject.FindGameObjectsWithTag("Enemy");
            foreach(GameObject g in ennemies)
            {
                if (Vector3.Distance(transform.position, g.transform.position) < radiusShockWave)
                {
                    Rigidbody enemyRb = g.gameObject.GetComponent<Rigidbody>();
                    Vector3 oppositePlayer = (enemyRb.gameObject.transform.position - transform.position);

                    enemyRb.AddForce(oppositePlayer * shockWaveStrenght, ForceMode.Impulse);
                }
            }
        }
        
    }




}
