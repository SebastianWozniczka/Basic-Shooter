using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LogoScreen : MonoBehaviour
{
    private float timer;
    private float endScene;
    void Start()
    {
        timer = 0;
        endScene = 2;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > endScene)
        {
            newScene();
        }
    }

    private void newScene()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
