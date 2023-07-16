using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreAndLives : MonoBehaviour
{
    private int health = 3;
    private int score = 0;
    // Update is called once per frame
    public void hitted(string mobName)
    {
        health--;
        score--;
        Debug.Log("Hitted by " + mobName + ": Health = " + health + ", Score = " + score);
        if(health == 0)
        {
            Debug.Log("Game over");
        }
    }

    public void feedAnimal(string mobName)
    {
        score++;
        Debug.Log("Feeded" + mobName + ": Score = " + score);
    }
}
