using Random = System.Random;
using UnityEngine;
using System.Collections.Generic;
using System;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Cube _cube;
    [SerializeField] private GameObject _cubePrefab;
    [SerializeField] private int _minAmount;
    [SerializeField] private int _maxAmount;

    private List<Rigidbody> _explosionObjects;
    private Random _random = new Random();

    public event Action Exploded;

    public void Spawn()
    {
        int propability = _random.Next(_cube.MaxChance + 1);

        if (propability > 0 && propability <= _cube.CurrentMaxChance)
        {
            int amount = _random.Next(_minAmount, _maxAmount);

            for (int i = 0; i < amount; i++)
            {
                GameObject cube = Instantiate(_cubePrefab, _cube.Position, Quaternion.identity);
                cube.GetComponent<Cube>().Initialise(_cube.Scale);
                _explosionObjects.Add(cube.GetComponent<Collider>().attachedRigidbody);
            }

            if (_explosionObjects.Count > 0)
                Exploded?.Invoke();

            _explosionObjects.Clear();
        }
    }

    public IEnumerable<Rigidbody> GetRigidbodies()
    {
        for (int i = 0; i < _explosionObjects.Count; i++)
            yield return _explosionObjects[i];
    }

    private void OnEnable()
    {
        _cube.Spawning += Spawn;
        _explosionObjects = new List<Rigidbody>();
    }

    private void OnDisable()
    {
        _cube.Spawning -= Spawn;
    }
}
