using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AccidentCounter : MonoBehaviour
{
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
    }

}
