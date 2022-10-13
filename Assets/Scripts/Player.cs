using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Player : MonoBehaviour
{
    public AudioSource source;
    public AudioClip newTrack;
    public GameObject aura1;
    public GameObject bulletPrefab;
    public Rigidbody2D playerRigidbody2D;
    public Transform tr2;
    private Vector3 startDist;
    private Vector3 theNewPos;

    private float x, y,z;
    private int maxBullets = 1000;
    public float speed = 20f;
    private float timer;
    private int velocity = 500;
    private float distance;
    private bool dragging = false;
    void Start()
    {
        x = transform.position.x;
        timer = 0;
        z = 0;

        StartCoroutine(Delay());
    }

   

    IEnumerator Delay()
    {
        for (int i = 1; i < maxBullets; i++)
        {
            yield return new WaitForSeconds(1f);
           
            {
                theNewPos = new Vector3(bulletPrefab.transform.position.x, bulletPrefab.transform.position.y, z);
              
                GameObject go= Instantiate(bulletPrefab, theNewPos, Quaternion.identity); 
                go.GetComponent<Rigidbody2D>().AddForce(new Vector3(velocity, z, z), ForceMode2D.Force);
                
                Destroy(go,2);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name.Contains("point1"))
        {
            source.Play();
        }
    }

    void OnMouseDown()
    {
        distance = Vector3.Distance(transform.position, Camera.main.transform.position);
        dragging = true;
       
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Vector3 rayPoint = ray.GetPoint(distance);
        startDist = transform.position - rayPoint;
    }

    void OnMouseUp()
    {
        dragging = false;
    }
    void Update()
    {

        auraRotation();

        playerPostion();

        playerDrag();

        
    }

    private void playerDrag()
    {
        if (dragging)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Vector3 rayPoint = ray.GetPoint(distance);

            Vector3 target = rayPoint + startDist;

            float velY = playerRigidbody2D.velocity.y * 100;
            float velX = playerRigidbody2D.velocity.x * 100;
            Vector3 vel = new Vector3(velX, velY, 0);
            transform.position = Vector3.SmoothDamp(transform.position, rayPoint, ref vel, 0.1f);

            float y2 = transform.position.y;
            if (y2 < y)
                transform.Rotate(-distance / 100, 0, 0);
            if (y2 > y)
                transform.Rotate(distance / 300, 0, 0);
        }
        else
            transform.rotation = Quaternion.identity;
    }

    private void playerPostion()
    {
        x += 0.03f;

        y = transform.position.y;
    }

    private void auraRotation()
    {
        transform.rotation = Quaternion.identity;
        tr2.RotateAround(tr2.position, new Vector3(0, 0, -1), -15);
    }
}
