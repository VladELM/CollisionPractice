using System.Collections.Generic;
using UnityEngine;

public class ObjectInitialization : MonoBehaviour
{
    public void Initialise(Vector3 scale, Color color)
    {
        transform.localScale = scale;
        GetComponent<Renderer>().material.color = color;
    }
}
