using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object : MonoBehaviour
{
    public void Destroy()
    {
        Destroy(gameObject);
    }
}
