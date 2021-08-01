using PaintIn3D;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HappyAccidentHandler : MonoBehaviour
{
    public static event Action<float> HappyMistakeTriggered;
    
    public float mistakePercentToTriggerAction = 1f;

    private P3dPaintableTexture paintableTexture;
    private P3dChangeCounter changeCounter;
    private Texture completePaintingTexture;


    private void Awake()
    {
        paintableTexture = GetComponent<P3dPaintableTexture>();
        changeCounter = GetComponent<P3dChangeCounter>();
        completePaintingTexture = paintableTexture.Texture;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Brush")
        {
            paintableTexture.Clear(completePaintingTexture, Color.white);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Brush")
        {
            float mistakePercent = 100f / changeCounter.Total * (changeCounter.Total - changeCounter.Count);

            if (mistakePercent >= mistakePercentToTriggerAction)
            {
                HappyMistakeTriggered?.Invoke(changeCounter.Ratio);
            }
        }
    }
}
