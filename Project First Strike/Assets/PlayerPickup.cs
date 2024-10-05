using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPickup : MonoBehaviour
{
    public GameObject vortex;

    private float timer = 0.0f;

    private bool active = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "GroundItem")
        {
            vortex.SetActive(true);
            active = true;
        }
    }

    private void Update()
    {
        if (active)
        {
            timer += Time.deltaTime;
            if(timer > 0.5f)
            {
                vortex.SetActive(false);
                timer = 0.0f;
                active = false;
            }
        }
    }
}
