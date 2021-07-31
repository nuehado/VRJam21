using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PaintIn3D;

public class PaintColorChanger : MonoBehaviour
{
    [SerializeField] Color paintcolor;


    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("collision");
        if (collision.gameObject.tag == "Brush")
        {
            collision.gameObject.GetComponent<P3dPaintDecal>().Color = paintcolor;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("trigger");
        if (other.tag == "Brush")
        {
            other.GetComponent<P3dPaintDecal>().Color = paintcolor;
        }
    }
}
