using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Button nGame,load,exit;
    public new SpriteRenderer renderer;
    private bool ng=false;

    private float x,y,z,endoftheMap;
    
    void Start()
    {
        nGame.onClick.AddListener(newGame);
        exit.onClick.AddListener(Exit);

        y = renderer.transform.position.y;
        x = renderer.transform.position.x;
        z = 0;
        endoftheMap = 10;
       
    }

    private void newGame()
    {
        ng = true;
    }

    private void Exit()
    {
        Application.Quit();
    }

    void Update()
    {
        renderer.transform.position = new Vector3(x, y, z);

        if (ng)
        {
            newScene();
        }
    }

    private void newScene()
    {
        y += 0.1f;
        if (y >= endoftheMap)
        {
            SceneManager.LoadScene("Mission1");
        }
    }
}
