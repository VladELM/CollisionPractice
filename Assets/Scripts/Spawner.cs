using Random = System.Random;
using UnityEngine;
using System.Collections.Generic;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Manager _manager;
    [SerializeField] private Cube _cube;
    [SerializeField] private int _minAmount;
    [SerializeField] private int _maxAmount;
    [SerializeField] private int _scaleDivider;
    [SerializeField] private int _chanceDivider;

    private List<Rigidbody> _explosionObjects;
    private Random _random = new Random();
    private int _maxChance;

    public int RigidbodiesAmount => _explosionObjects.Count;

    private void OnEnable()
    {
        _maxChance = 100;
        _explosionObjects = new List<Rigidbody>();
        _manager.Spawned += Spawn;
        _manager.Removed += RemoveRigidbodies;
    }

    private void OnDisable()
    {
        _manager.Spawned -= Spawn;
        _manager.Removed -= RemoveRigidbodies;
    }

    private void Spawn(Vector3 position, Vector3 scale, int chance)
    {
        int propability = _random.Next(_maxChance + 1);

        if (propability > 0 && propability <= chance)
        {
            int amount = _random.Next(_minAmount, _maxAmount);
            int reducedChance = chance / _chanceDivider;

            for (int i = 0; i < amount; i++)
            {
                var cube = Instantiate(_cube, position, Quaternion.identity);
                cube.transform.localScale = scale / _scaleDivider;
                cube.Initialize(reducedChance);
                
                if (cube.TryGetComponent(out Rigidbody rigidbody))
                    _explosionObjects.Add(rigidbody);
            }
        }
    }

    private void RemoveRigidbodies()
    {
        _explosionObjects.Clear();
    }

    public IEnumerable<Rigidbody> GetRigidbodies()
    {
        for (int i = 0; i < _explosionObjects.Count; i++)
            yield return _explosionObjects[i];
    }
}
