using UnityEngine;
using System.Collections.Generic;

public class InputReading : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private float _rayLength;
    [SerializeField] private LayerMask _impactRaycastLayer;
    [SerializeField] private ObjectsCreating _objectsCreating;
    [SerializeField] private Exploding _exploding;

    private void Update()
    {
        CastRay();
    }

    private void CastRay()
    {
        Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(ray.origin, ray.direction * _rayLength, Color.red);

        ReadMouseClick(ray);
    }

    private void ReadMouseClick(Ray ray)
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, _rayLength, _impactRaycastLayer))
            {
                if (hit.collider.gameObject.GetComponent<ObjectInitialization>())
                {
                    _objectsCreating.Create(hit.transform.position, hit.transform.localScale, out List<Rigidbody> explosionObjects);

                    if (explosionObjects.Count > 0)
                        _exploding.Explode(explosionObjects, hit.transform.position);

                    Destroy(hit.collider.gameObject);
                }
            }
        }
    }
}
