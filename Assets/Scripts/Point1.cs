using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Point1 : MonoBehaviour
{
    private float x, velocity;
    private float bonus = 1;
    private String playerName;
    void Start()
    {
        x = transform.position.x;
        velocity = 0.05f;
        playerName = "player_2";
    }

    void Update()
    {
        transportPoints();
    }

    private void transportPoints()
    {
        transform.position = new Vector2(x, transform.position.y);
        x -= velocity;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == playerName)
        {
            destroyPoints();
        }
    }

    private void destroyPoints()
    {
        Variables var = new Variables(); 
        Variables.points += bonus;
        Destroy(gameObject);
    }
}
