using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Autohand;

public class ArmControl : MonoBehaviour
{
    [SerializeField] private Transform hairTarget;
    [SerializeField] private Transform armTarget;

    private Vector3 hairTargetLastPos;

    [SerializeField] private float scalar = 1;

    // Start is called before the first frame update
    void Start()
    {

        hairTargetLastPos = hairTarget.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        //if(hairTarget.localPosition != hairTargetLastPos)
        //{
            //armTarget.localPosition = (hairTarget.localPosition - hairTargetLastPos) * scalar;
            armTarget.localPosition = hairTarget.localPosition * scalar;
        //}
        //hairTargetLastPos = hairTarget.localPosition;
        
    }

    public void ResetHairTarget()
    {
        hairTarget.localPosition = Vector3.zero;
    }
}
