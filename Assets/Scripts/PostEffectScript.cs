using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[ExecuteInEditMode]
public class PostEffectScript : MonoBehaviour
{
    public Material mat;

    void onRenderImage(RenderTexture src, RenderTexture dest)
    {
        Color[] pixels = new Color[1920 * 1080];

        for (int x = 0; x < 1920; x++)
        {
            for (int y = 0; y < 1080; y++)
            {
                pixels[x + y * 1080].r = Mathf.Pow(2.18f, 3.17f);
            }
        }

        Graphics.Blit(src, dest, mat);
    }


}
