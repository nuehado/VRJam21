using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PaintIn3D;
using System;
using UnityEngine.UI;

public class GalleryHadler : MonoBehaviour
{
    [SerializeField] P3dPaintableTexture easle;

    private void OnEnable()
    {
        PercentCompleteEvents.pastPercentDoneThreshold3 += UnlockGallery;
    }

    private void OnDisable()
    {
        PercentCompleteEvents.pastPercentDoneThreshold3 -= UnlockGallery;
    }

    private void UnlockGallery(P3dPaintableTexture obj)
    {
        if (obj == easle)
        {
            GetComponent<Image>().enabled = true;
        }
    }
}
