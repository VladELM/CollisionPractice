using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exploding : MonoBehaviour
{
    [SerializeField] private float _explosionForce;
    [SerializeField] private float _explosionRadius;

    public void Explode(List<Rigidbody> exploadObjects, Vector3 explosionPoint)
    {
        foreach (Rigidbody exploadObject in exploadObjects)
        {
            exploadObject.AddExplosionForce(_explosionForce, explosionPoint, _explosionRadius);
            Debug.Log("Bum!!!");
        }
    }
}
