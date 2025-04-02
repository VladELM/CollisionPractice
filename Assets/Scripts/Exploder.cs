using UnityEngine;

public class Exploder : MonoBehaviour
{
    [SerializeField] private Cube _cube;
    [SerializeField] private Spawner _spawner;
    [SerializeField] private float _explosionForce;
    [SerializeField] private float _explosionRadius;

    private void Explode()
    {
        foreach (Rigidbody explodableObject in _spawner.GetRigidbodies())
            explodableObject.AddExplosionForce(_explosionForce, _cube.Position, _explosionRadius);
    }

    private void OnEnable()
    {
        _spawner.Exploded += Explode;
    }

    private void OnDisable()
    {
        _spawner.Exploded -= Explode;
    }
}
