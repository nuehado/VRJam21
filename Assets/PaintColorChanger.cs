using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PaintIn3D;
using System.Linq;

public class PaintColorChanger : MonoBehaviour
{
    [SerializeField] Color paintcolor;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Brush")
        {
            other.GetComponentInChildren<MeshRenderer>().material.color = paintcolor;


            List<P3dPaintDecal> brushDecals = other.GetComponents<P3dPaintDecal>().ToList();

            foreach (var decal in brushDecals)
            {
                decal.Color = paintcolor;
            }            
        }
    }
}
