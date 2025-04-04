using System.Collections;
using UnityEngine;
using System;

public class Manager : MonoBehaviour
{
    [SerializeField] private InputReader _inputReader;
    [SerializeField] private Spawner _spawner;
    [SerializeField] private Camera _camera;
    [SerializeField] private float _rayLength;
    [SerializeField] private LayerMask _impactRaycastLayer;

    public delegate void Spawn(Vector3 position, Vector3 scale, int chance);
    public event Spawn Spawned;
    public delegate void Explode(IEnumerable rigidbodies, Vector3 position);
    public event Explode Exploded;
    public event Action Removed;

    private void OnEnable()
    {
        _inputReader.Pushed += ProcessPushing;
    }

    private void OnDisable()
    {
        _inputReader.Pushed -= ProcessPushing;
    }

    private void ProcessPushing(Vector3 position)
    {
        Ray ray = _camera.ScreenPointToRay(position);
        Debug.DrawRay(ray.origin, ray.direction * _rayLength, Color.red);

        if (Physics.Raycast(ray, out RaycastHit hit, _rayLength, _impactRaycastLayer))
        {
            if (hit.transform.gameObject.TryGetComponent(out Cube cube))
            {
                Transform cubeTransform = hit.transform;
                Spawned?.Invoke(cubeTransform.position, cubeTransform.localScale, cube.Chance);
                
                if (_spawner.RigidbodiesAmount > 0)
                {
                    Exploded?.Invoke(_spawner.GetRigidbodies(), cubeTransform.position);
                    Removed?.Invoke();
                }

                Destroy(cubeTransform.gameObject);
            }
        }

    }
}
