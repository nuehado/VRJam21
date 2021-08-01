using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PaintIn3D;
using System;

public class PercentCompleteEvents : MonoBehaviour
{
    public static event Action<P3dPaintableTexture> pastPercentDoneThreshold1;
    public static event Action<P3dPaintableTexture> pastPercentDoneThreshold2;
    public static event Action<P3dPaintableTexture> pastPercentDoneThreshold3;
    public static event Action<P3dPaintableTexture> pastPercentDoneThreshold4;

    //out of 1
    [SerializeField] float percentDoneThreshold1 = 0.2f;
    [SerializeField] float percentDoneThreshold2 = 0.5f;
    [SerializeField] float percentDoneThreshold3 = 0.7f;
    [SerializeField] float percentDoneThreshold4 = 0.9f;

    private P3dChangeCounter changeCounter;

    private float previousRatio;

    void Start()
    {
        changeCounter = GetComponent<P3dChangeCounter>();

        
    }

    // Update is called once per frame
    void Update()
    {
        if (changeCounter.Ratio > percentDoneThreshold4 && previousRatio <= percentDoneThreshold4)
        {
            Debug.Log(percentDoneThreshold4 * 100 + " percent done");
            pastPercentDoneThreshold4?.Invoke(GetComponent<P3dPaintableTexture>());
        }
        else if (changeCounter.Ratio > percentDoneThreshold3 && previousRatio <= percentDoneThreshold3)
        {
            Debug.Log(percentDoneThreshold3 * 100 + " percent done");
            pastPercentDoneThreshold3?.Invoke(GetComponent<P3dPaintableTexture>());
        }
        else if (changeCounter.Ratio > percentDoneThreshold2 && previousRatio <= percentDoneThreshold2)
        {
            Debug.Log(percentDoneThreshold2 * 100 + " percent done");
            pastPercentDoneThreshold2?.Invoke(GetComponent<P3dPaintableTexture>());
        }
        else if (changeCounter.Ratio > percentDoneThreshold1 && previousRatio <= percentDoneThreshold1)
        {
            Debug.Log(percentDoneThreshold1 * 100 + " percent done");
            pastPercentDoneThreshold1?.Invoke(GetComponent<P3dPaintableTexture>());
        }

        previousRatio = changeCounter.Ratio;
    }
}
