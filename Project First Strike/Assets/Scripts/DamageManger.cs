using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DamageManger : MonoBehaviour
{
    public Slider healthBar;
    public Slider shieldBar;
    int timeCount = 0;
    System.Random random = new System.Random();

    // Start is called before the first frame update
    void Start()
    {
        healthBar.maxValue = 100;
        shieldBar.maxValue = 100;

        healthBar.minValue = 0;
        shieldBar.minValue = 0;

        healthBar.value = 100;
        shieldBar.value = 20;
        InvokeRepeating("SimulateDamage", 0, 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SimulateDamage()
    {
        timeCount++;

        int damage = random.Next(1, 4);

        if(damage == 1 && healthBar.value != 0)
        {
            timeCount = 0;
            if(shieldBar.value > 0)
            {
                shieldBar.value -= 5;
            }
            else
            {
                healthBar.value -= 5;
            }
        }

        if(timeCount >= 5)
        {
            shieldBar.value += 5;
        }
    }
}
