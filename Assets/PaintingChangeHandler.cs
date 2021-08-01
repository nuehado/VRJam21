using PaintIn3D;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PaintingChangeHandler : MonoBehaviour
{
    [SerializeField] List<P3dPaintableTexture> easles = new List<P3dPaintableTexture>();
    P3dPaintableTexture currentPainting;

    [SerializeField] Transform percentCorrentUI;
    [SerializeField] Transform percentBadUI;


    private void Start()
    {
        currentPainting = easles[0];
    }

    private void OnEnable()
    {
        ChangePaintingController.PaintingChanged += ChangePainting;
    }

    private void OnDisable()
    {
        ChangePaintingController.PaintingChanged -= ChangePainting;
    }

    private void ChangePainting(bool next)
    {        
        percentCorrentUI.GetComponentInChildren<P3dChangeCounterFill>().Counters.Clear();
        percentCorrentUI.GetComponentInChildren<P3dChangeCounterText>().Counters.Clear();

        percentBadUI.GetComponentInChildren<P3dChangeCounterFill>().Counters.Clear();
        percentBadUI.GetComponentInChildren<P3dChangeCounterText>().Counters.Clear();
        
        currentPainting.gameObject.SetActive(false);

        if (next)
        {
            for (int i = 0; i < easles.Count; i++)
            {
                if (i == easles.Count - 1)
                {
                    currentPainting = easles[0];
                    break;
                }
                else if (easles[i] == currentPainting)
                {
                    currentPainting = easles[i + 1];
                    break;
                }
            }
        }
        else
        {
            for (int i = easles.Count -1; i >= 0 ; i--)
            {
                if (i == 0)
                {
                    currentPainting = easles[easles.Count - 1];
                    break;
                }
                else if (easles[i] == currentPainting)
                {
                    currentPainting = easles[i - 1];
                    break;
                }
            }
        }
        

        percentCorrentUI.GetComponentInChildren<P3dChangeCounterFill>().Counters.Add(currentPainting.GetComponent<P3dChangeCounter>());
        percentCorrentUI.GetComponentInChildren<P3dChangeCounterText>().Counters.Add(currentPainting.GetComponent<P3dChangeCounter>());

        percentBadUI.GetComponentInChildren<P3dChangeCounterFill>().Counters.Add(currentPainting.GetComponentInChildren<HappyAccidentHandler>().GetComponent<P3dChangeCounter>());
        percentBadUI.GetComponentInChildren<P3dChangeCounterText>().Counters.Add(currentPainting.GetComponentInChildren<HappyAccidentHandler>().GetComponent<P3dChangeCounter>());
        currentPainting.gameObject.SetActive(true);
    }
}
