using PaintIn3D;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffectCaller : MonoBehaviour
{
    AudioSource audioPlayer;
    
    [SerializeField] AudioClip accidentSFX1;
    [SerializeField] AudioClip accidentSFX2;
    [SerializeField] AudioClip accidentSFX3;
    [SerializeField] AudioClip accidentSFX4;

    [SerializeField] AudioClip successSFX1;
    [SerializeField] AudioClip successSFX2;
    [SerializeField] AudioClip successSFX3;
    [SerializeField] AudioClip successSFX4;


    bool playingSound = false;

    private void Start()
    {
        audioPlayer = GetComponent<AudioSource>();
    }


    private void OnEnable()
    {
        AccidentCounter.AccidentThreshold1Reached += PlayAccidentThreshold_1_Sound;
        AccidentCounter.AccidentThreshold2Reached += PlayAccidentThreshold_2_Sound;
        AccidentCounter.AccidentThreshold3Reached += PlayAccidentThreshold_3_Sound;
        AccidentCounter.AccidentThreshold4Reached += PlayAccidentThreshold_4_Sound;

        PercentCompleteEvents.pastPercentDoneThreshold1 += PlaySuccessThreshold_1_Sound;
        PercentCompleteEvents.pastPercentDoneThreshold2 += PlaySuccessThreshold_2_Sound;
        PercentCompleteEvents.pastPercentDoneThreshold3 += PlaySuccessThreshold_3_Sound;
        PercentCompleteEvents.pastPercentDoneThreshold4 += PlaySuccessThreshold_4_Sound;
    }

    private void OnDisable()
    {
        AccidentCounter.AccidentThreshold1Reached -= PlayAccidentThreshold_1_Sound;
        AccidentCounter.AccidentThreshold2Reached -= PlayAccidentThreshold_2_Sound;
        AccidentCounter.AccidentThreshold3Reached -= PlayAccidentThreshold_3_Sound;
        AccidentCounter.AccidentThreshold4Reached -= PlayAccidentThreshold_4_Sound;

        PercentCompleteEvents.pastPercentDoneThreshold1 -= PlaySuccessThreshold_1_Sound;
        PercentCompleteEvents.pastPercentDoneThreshold2 -= PlaySuccessThreshold_2_Sound;
        PercentCompleteEvents.pastPercentDoneThreshold3 -= PlaySuccessThreshold_3_Sound;
        PercentCompleteEvents.pastPercentDoneThreshold4 -= PlaySuccessThreshold_4_Sound;
    }

    private void PlaySuccessThreshold_1_Sound(P3dPaintableTexture obj)
    {
        StartCoroutine(PlaySound(successSFX1));
    }

    private void PlaySuccessThreshold_2_Sound(P3dPaintableTexture obj)
    {
        StartCoroutine(PlaySound(successSFX2));
    }

    private void PlaySuccessThreshold_3_Sound(P3dPaintableTexture obj)
    {
        StartCoroutine(PlaySound(successSFX3));
    }

    private void PlaySuccessThreshold_4_Sound(P3dPaintableTexture obj)
    {
        StartCoroutine(PlaySound(successSFX4));
    }

    private void PlayAccidentThreshold_1_Sound()
    {
        StartCoroutine(PlaySound(accidentSFX1));
    }

    private void PlayAccidentThreshold_2_Sound()
    {
        StartCoroutine(PlaySound(accidentSFX2));
    }

    private void PlayAccidentThreshold_3_Sound()
    {
        StartCoroutine(PlaySound(accidentSFX3));
    }

    private void PlayAccidentThreshold_4_Sound()
    {
        StartCoroutine(PlaySound(accidentSFX4));
    }

    IEnumerator PlaySound(AudioClip sfx)
    {
        while (playingSound)
        {
            yield return new WaitForSeconds(.1f);
        }

        playingSound = true;

        audioPlayer.PlayOneShot(sfx);

        yield return new WaitForSeconds(sfx.length);
        playingSound = false;
    }
    
}
