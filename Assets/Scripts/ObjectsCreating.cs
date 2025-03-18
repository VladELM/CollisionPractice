using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectsCreating : MonoBehaviour
{
    [SerializeField] private GameObject _cubePrefab;
    [SerializeField] private InputReading _inputReading;

    public void CreateObjects(Vector3 position)
    {
        Instantiate(_cubePrefab, position, Quaternion.identity);
    }
}
