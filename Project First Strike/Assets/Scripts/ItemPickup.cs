using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    private bool pickUp = false;
    private bool suckIn = false;

    private Vector2 playerLocation;

    public GameObject item;

    private Collider2D player;


    private void Update()
    {
        if (pickUp)
        {
            playerLocation = player.transform.position;
            playerLocation.x -= 1.62f;
            playerLocation.y += 1.5f;
            item.transform.position = Vector2.MoveTowards(item.transform.position, playerLocation, 0.02f);
            if (Math.Abs(item.transform.position.x) - Math.Abs(playerLocation.x) < 0.2f && Math.Abs(item.transform.position.y) - Math.Abs(playerLocation.y) < 0.2f)
            {
                pickUp = false;
                suckIn = true;
            }
        }


        if (suckIn)
        {
            playerLocation = player.transform.position;
            playerLocation.x -= 1.62f;
            playerLocation.y += 1.5f;
            item.transform.position = Vector2.MoveTowards(item.transform.position, playerLocation, 0.1f);

            Vector3 scaleChange = new Vector3(-0.01f, -0.01f, 0);

            item.transform.localScale = item.transform.localScale + scaleChange;
            if (item.transform.localScale.x < 0.1f)
            {
                suckIn = false;
                item.SetActive(false);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            player = other;
            pickUp = true;
        }
    }
}
