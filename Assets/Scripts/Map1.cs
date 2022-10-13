using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map1 : MonoBehaviour
{
    private float x, y,velocity;
    void Start()
    {
        x = transform.position.x;
        y = transform.position.y;
        velocity = 0.03f;
    }
    void Update()
    {
        transformMaps();
    }

    private void transformMaps()
    {
        x -= velocity;
        transform.position = new Vector2(x, y);
    }
}
