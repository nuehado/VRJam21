using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AccidentCounter : MonoBehaviour
{
    [SerializeField] float accidentThreshold1 = 10;
    [SerializeField] float accidentThreshold2 = 30;
    [SerializeField] float accidentThreshold3 = 50;
    [SerializeField] float accidentThreshold4 = 100;

    public static event Action AccidentThreshold1Reached;
    public static event Action AccidentThreshold2Reached;
    public static event Action AccidentThreshold3Reached;
    public static event Action AccidentThreshold4Reached;

    private Text counterText;
    private int accidentCount = 0;

    void Start()
    {
        counterText = GetComponent<Text>();
        HappyAccidentHandler.HappyMistakeTriggered += IncrementAccidentCounter; 
    }

    private void IncrementAccidentCounter(float percentBad)
    {
        accidentCount ++;
        counterText.text = $"{accidentCount}\r\nHappy\r\nAccidents!";

        if (accidentCount == accidentThreshold1)
        {
            Debug.Log(accidentThreshold1 + " accidents");
            AccidentThreshold1Reached?.Invoke();
        }
        else if (accidentCount == accidentThreshold2)
        {
            Debug.Log(accidentThreshold2 + " accidents");
            AccidentThreshold2Reached?.Invoke();
        }
        else if (accidentCount == accidentThreshold3)
        {
            Debug.Log(accidentThreshold3 + " accidents");
            AccidentThreshold3Reached?.Invoke();
        }
        else if (accidentCount == accidentThreshold4)
        {
            Debug.Log(accidentThreshold4 + " accidents");
            AccidentThreshold4Reached?.Invoke();
        }
    }

}
