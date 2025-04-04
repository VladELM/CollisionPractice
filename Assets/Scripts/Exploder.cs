using System.Collections;
using UnityEngine;

public class Exploder : MonoBehaviour
{
    [SerializeField] private Manager _manager;
    [SerializeField] private float _explosionForce;
    [SerializeField] private float _explosionRadius;

    private void Explode(IEnumerable explodableObjects, Vector3 position)
    {
        foreach (Rigidbody explodableObject in explodableObjects)
            explodableObject.AddExplosionForce(_explosionForce, position, _explosionRadius);
    }

    private void OnEnable()
    {
        _manager.Exploded += Explode;
    }

    private void OnDisable()
    {
        _manager.Exploded -= Explode;
    }
}
