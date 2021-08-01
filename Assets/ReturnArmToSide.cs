using Autohand;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnArmToSide : MonoBehaviour
{
    [SerializeField] float armFallSpeed = 0.5f;


    private Vector3 targetStartingPos;
    private Vector3 localStartingPosition;
    private Quaternion localStartingRotation;
    private Grabbable targetGrabbable;
    bool isReleased = true;
    [SerializeField] bool useLocal;
    
    // Start is called before the first frame update
    void Awake()
    {
        targetStartingPos = transform.position;
        targetGrabbable = GetComponent<Grabbable>();
        localStartingPosition = transform.localPosition;
        localStartingRotation = transform.localRotation;
    }
    private void OnEnable()
    {
        if (useLocal == false)
        {
            targetGrabbable.OnReleaseEvent += LerpTowardsStartingPos;
            targetGrabbable.OnGrabEvent += TurnArmLerpOff;
        }
        else
        {
            HappyAccidentHandler.BrushLeftCanvas += LerpTowardsLocal;

        }
    }

    private void LerpTowardsLocal()
    {
        transform.localPosition = localStartingPosition;
        transform.localRotation = localStartingRotation;
    }

    private void OnDisable()
    {
        if (useLocal == false)
        {
            targetGrabbable.OnReleaseEvent -= LerpTowardsStartingPos;
            targetGrabbable.OnGrabEvent += TurnArmLerpOff;
        }
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
