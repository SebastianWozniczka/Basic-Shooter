
using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Hud : MonoBehaviour
{


    public Slider health, mana;
    public Transform tr;
    public AudioSource audio1, alert;
    public TMPro.TextMeshProUGUI pkt, meter;
    public Camera cam;
    public GameObject aura1, player;
    private GameObject go;

    private Variables var;

    public bool isSecure;
    public float t;
    private bool maxM;
    private bool collide,newAura1=false;
   public void Start()
    {
        var = new Variables();
        isSecure = true;
        t = 0;
        health.value = var.hp / 10;
        mana.value = var.m / 10;
        pkt.text = "" + Variables.points;
        
    }



    private void Collision()
    {
         var.hp -= 3f;
         var.m -= 3f;
         collide = false;
    }

   public void Update()
    {
        hudAppearance();

        

        if (var.hp <= 1)
        {
            newScene();   
        }


        if (Asteroid.collide == true)
        {
            asteriodCollision();
        }

        if (maxM)
            fullHp();
            
        if (!isSecure)
            if (collide)
            {
                Collision();
            }

        if (var.m >= 10)
        {
            newAura1 = true;
            if (newAura1 && !isSecure)
                Aura1();
            var.m = 10;
            isSecure = true;
        }

        
    }

    private void fullHp()
    {
        go.transform.RotateAround(go.transform.position, new Vector3(0, 0, -1), -15);
    }

    private void asteriodCollision()
    {
        Asteroid.collide = false;
        audio1.Play();
        collide = true;
        var.hp -= 1f;
        isSecure = false;
    }

    private void newScene()
    {
        SceneManager.LoadScene("Finish");
    }

    private void hudAppearance()
    {
        t += Time.deltaTime;

        pkt.text = "" + Variables.points;
        health.value = var.hp / 10;
        mana.value = var.m / 10;
        meter.text = t + " s";

        if (var.m <= 0)
            var.m = 0;

        if (!isSecure)
            var.m += 0.0009f;

    }

    private void Aura1()
    {
        go = Instantiate(aura1, tr.position, Quaternion.identity);
        go.transform.parent = player.transform;
        go.transform.localScale = new Vector2(10, 10);
        maxM = true;
        newAura1 = false;
    }
}
