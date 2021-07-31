using Autohand;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnArmToSide : MonoBehaviour
{
    [SerializeField] float armFallSpeed = 0.5f;


    private Vector3 targetStartingPos;
    private Grabbable targetGrabbable;
    bool isReleased = true;
    
    // Start is called before the first frame update
    void Awake()
    {
        targetStartingPos = transform.position;
        targetGrabbable = GetComponent<Grabbable>();
    }
    private void OnEnable()
    {
        targetGrabbable.OnReleaseEvent += LerpTowardsStartingPos;
        targetGrabbable.OnGrabEvent += TurnArmLerpOff;
    }
    private void OnDisable()
    {
        targetGrabbable.OnReleaseEvent -= LerpTowardsStartingPos;
        targetGrabbable.OnGrabEvent += TurnArmLerpOff;
    }


    private void LerpTowardsStartingPos(Hand hand, Grabbable grabbable)
    {
        isReleased = true;
    }

    private void TurnArmLerpOff(Hand hand, Grabbable grabbable)
    {
        isReleased = false;
    }

    

    private void FixedUpdate()
    {
        if (isReleased)
        {
            transform.position = Vector3.Lerp(transform.position, targetStartingPos, armFallSpeed);
        }
    }
}
