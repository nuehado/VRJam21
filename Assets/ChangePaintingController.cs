using Autohand;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangePaintingController : MonoBehaviour
{
    public static event Action<bool> PaintingChanged; 
    
    
    private PhysicsGadgetConfigurableLimitReader changePaintingHandle;
    [SerializeField] private float minTimeBetweenChange = 3f;

    bool areMidChange = false;

    // Start is called before the first frame update
    void Awake()
    {
        changePaintingHandle = GetComponent<PhysicsGadgetConfigurableLimitReader>();
    }

    // Update is called once per frame
    void Update()
    {
        if (changePaintingHandle.GetValue() < -0.9f)
        {            
            StartCoroutine(ChangePainting(true));
        }

        if (changePaintingHandle.GetValue() > 0.9f)
        {
            StartCoroutine(ChangePainting(false));
        }
    }


    public IEnumerator ChangePainting(bool next)
    {
        if (areMidChange)
        {
            yield break;
        }

        areMidChange = true;

        PaintingChanged?.Invoke(next);
        
        yield return new WaitForSeconds(minTimeBetweenChange);

        areMidChange = false;
        
    }

}
