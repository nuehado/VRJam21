using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrushSelector : MonoBehaviour
{
    [SerializeField] private GameObject[] brushTips;
    [SerializeField] private int indexOfThisTip;

    private void OnTriggerEnter()
    {
        for(int i = 0; i < brushTips.Length; i++)
        {
            if(i == indexOfThisTip)
            {
                brushTips[i].SetActive(true);
            }
            else
            {
                brushTips[i].SetActive(false);
            }
        }
    }
}
