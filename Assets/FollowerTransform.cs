using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowerTransform : MonoBehaviour
{
    [SerializeField] float followSpeed = 0.5f;
    [SerializeField] Transform followingTrans;

    private void FixedUpdate()
    {
        transform.position = followingTrans.position;
    }
}
