using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stamina : MonoBehaviour
{
    public new SpriteRenderer renderer;
   
    private float x;   
    private float alpha = 1;
    private float timer;
    bool newObject = false;
    float randomNumber;
    void Start()
    {
        x = transform.position.x;
        renderer.color = new Color(1, 1, 1, alpha);
        randomNumber = UnityEngine.Random.Range(5, 10);
    }

    
    void Update()
    {

        flashImage();

        randomizeImage();

    }

    private void randomizeImage()
    {
        if (timer > randomNumber)
        {
            if (newObject == false)
                CreateObject();
            timer = 0;
        }
    }

    private void flashImage()
    {
        transform.position = new Vector2(x, transform.position.y);
        renderer.color = new Color(1, 1, 1, alpha);
        timer += Time.deltaTime;

        x -= 0.02f;

        fadeOut();
    }

    private void CreateObject()
    {
        Instantiate(gameObject, new Vector3(-4, 1,0), Quaternion.identity);
        newObject = true;
    }

    private void fadeOut()
    {
        alpha -= 0.01f;
        if (alpha <= 0.1f)
        {
            alpha = 1;
            fadeIn();
        }
    }

    private void fadeIn()
    {
        alpha += 0.01f;
        if (alpha >= 0.9f)
        {
            alpha = 0.9f;
            fadeOut();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "player_2")
        {
            Variables var = new Variables();
            var.m += 9.9f;
            Destroy(gameObject);
        }
    }
}
