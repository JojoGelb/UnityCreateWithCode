using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{

    public ScoreAndLives scoreboard;

    private void OnTriggerEnter(Collider other)
    {
        scoreboard.hitted(other.name);
        Destroy(other.gameObject);
    }
}
