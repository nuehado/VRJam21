using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Autohand;

public class GrabOnStart : MonoBehaviour
{
    [SerializeField] private Hand hand;
    [SerializeField] private Grabbable paintBrush;

    // Start is called before the first frame update
    void Start()
    {
        hand.Grab();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
