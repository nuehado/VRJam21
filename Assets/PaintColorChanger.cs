using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PaintIn3D;

public class PaintColorChanger : MonoBehaviour
{
    [SerializeField] Color paintcolor;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Brush")
        {
            other.GetComponent<P3dPaintDecal>().Color = paintcolor;
        }
    }
}
