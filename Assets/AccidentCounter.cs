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
            AccidentThreshold1Reached?.Invoke();
        }
        else if (accidentCount == accidentThreshold2)
        {
            AccidentThreshold2Reached?.Invoke();
        }
        else if (accidentCount == accidentThreshold3)
        {
            AccidentThreshold3Reached?.Invoke();
        }
        else if (accidentCount == accidentThreshold4)
        {
            AccidentThreshold4Reached?.Invoke();
        }
    }

}
