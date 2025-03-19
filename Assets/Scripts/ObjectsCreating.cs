using Random = System.Random;
using UnityEngine;
using System.Collections.Generic;

public class ObjectsCreating : MonoBehaviour
{
    [SerializeField] private GameObject _cubePrefab;
    [SerializeField] private int _minAmount;
    [SerializeField] private int _maxAmount;
    [SerializeField] private int _chanceDivider;

    private int _maxChance = 100;
    private int _currentMaxChance;
    private Random _random = new Random();

    private void Start()
    {
        _currentMaxChance = _maxChance;
    }

    public void Create(Vector3 position, Vector3 scale, out List<Rigidbody> explosionObjects)
    {
        explosionObjects = new List<Rigidbody>();
        int propability = _random.Next(_maxChance + 1);

        if (propability > 0 && propability  <= _currentMaxChance)
        {
            int amount = _random.Next(_minAmount, _maxAmount);

            for (int i = 0; i < amount; i++)
            {
                GameObject cube = Instantiate(_cubePrefab, position, Quaternion.identity);
                cube.GetComponent<ObjectInitialization>().Initialise(scale);
                explosionObjects.Add(cube.GetComponent<Collider>().attachedRigidbody);
            }
        }
        
        _currentMaxChance /= _chanceDivider;
    }
}
