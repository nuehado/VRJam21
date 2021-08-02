using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeScript : MonoBehaviour
{

    public Animator whiteFadeAnimator;

    public float testWaitTime;
    public bool testFade;


    // Update is called once per frame
    void Update()
    {
        if (testFade)
        {
            TriggerFade(testWaitTime, "FadeToWhiteAndBackLoop");

            testFade = false;
        }
    }


    public void TriggerFade(float timeUntilFade, string fadeName, string sceneName = "null")
    {
        StartCoroutine(RunFadeAfterSeconds(timeUntilFade, fadeName, sceneName));
    }

    IEnumerator RunFadeAfterSeconds(float timeUntilFade, string fadeName, string sceneName)
    {
        yield return new WaitForSeconds(timeUntilFade);

        whiteFadeAnimator.SetTrigger(fadeName);

        if (sceneName != null)
        {
            if (Application.CanStreamedLevelBeLoaded(sceneName))
            {
                StartCoroutine(SceneChangeAfterSeconds(sceneName));
            }
            else
                Debug.LogError("Fade script - trying to find scene but the scene name does not exist");
        }
    }

    IEnumerator SceneChangeAfterSeconds(string sceneName)
    {
        yield return new WaitForSeconds(1);

    }
}
