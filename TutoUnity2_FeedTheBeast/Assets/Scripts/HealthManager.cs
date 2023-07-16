using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    public Slider slider;
    public int maxHealth = 1;
    private int health;

    private void Start()
    {
        health = maxHealth;
        slider.maxValue = maxHealth;
        slider.value = health;
    }

    public bool hit()
    {
        health--;
        slider.value = health;
        if(health == 0)
        {
            return true;
        }

        return false;
    }
    

}
