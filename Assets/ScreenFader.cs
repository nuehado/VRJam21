using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScreenFader : MonoBehaviour
{
    public Image image;
    
    [SerializeField] private float _speed = 1.0f;
    [SerializeField] private float _intensity = 0.0f;


    public Coroutine StartFadeIn()
    {
        StopAllCoroutines();
        return StartCoroutine(FadeIn());
    }

    private IEnumerator FadeIn()
    {
        _intensity = 0;

        while (_intensity <= 1.0f)
        {
            _intensity += _speed * Time.deltaTime;

            //JD
            Color tmp = image.color;
            tmp.a = _intensity;
            image.color = tmp;
            //Debug.Log(image.name + " alpha intensity = " + _intensity);

            yield return null;
        }
    }

    public Coroutine StartFadeOut()
    {
        StopAllCoroutines();
        return StartCoroutine(FadeOut());
    }

    private IEnumerator FadeOut()
    {
        _intensity = 1;

        while (_intensity >= 0.0f)
        {
            _intensity -= _speed * Time.deltaTime;

            //JD
            Color tmp = image.color;
            tmp.a = _intensity;
            image.color = tmp;
            //Debug.Log(image.name + " alpha intensity = " + _intensity);

            yield return null;
        }
    }
}


