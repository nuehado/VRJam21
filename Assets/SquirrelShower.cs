using PaintIn3D;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquirrelShower : MonoBehaviour
{
    ParticleSystem squirrelParticles;
    private void Awake()
    {
        squirrelParticles = GetComponent<ParticleSystem>();
    }

    private void OnEnable()
    {
        PercentCompleteEvents.pastPercentDoneThreshold1 += PlaySquirrels;
    }

    private void OnDisable()
    {
        PercentCompleteEvents.pastPercentDoneThreshold1 -= PlaySquirrels;
    }


    private void PlaySquirrels(P3dPaintableTexture obj)
    {
        squirrelParticles.Play();
    }
}
