using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollisions : MonoBehaviour
{

    public ScoreAndLives scoreboard;

    private void OnTriggerEnter(Collider other)
    {
        HealthManager health = other.GetComponent<HealthManager>();

        if (health != null && health.hit())
        {
            scoreboard.feedAnimal(other.name);
            Destroy(other.gameObject);
        }
        Destroy(gameObject);

    }
}
