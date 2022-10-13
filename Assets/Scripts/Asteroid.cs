using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public GameObject aura;
 
    public float x, y, z,angle,endoftheMap,velocity;
    public static bool collide;
 
    void Start()
    {
        objectsPositions();
    }

    private void objectsPositions()
    {
        x = transform.position.x;
        y = transform.position.y;
        z = transform.position.z;
        angle = 1;
        endoftheMap = 999;
        velocity = 0.1f;
    }

    void Update()
    {
        transform.position = new Vector3(x, y, z);
        transform.Rotate(angle, angle, angle);
        x -= velocity;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "player_2")
        {
            destroyAsteroid();
        }
    }

    private void destroyAsteroid()
    {
        GameObject go = aura;
        Destroy(gameObject);

        go.transform.position = new Vector2(endoftheMap, endoftheMap);

        collide = true;
    }
}
