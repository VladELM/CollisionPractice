using UnityEngine;
using System;

public class InputReader : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private float _rayLength;
    [SerializeField] private LayerMask _impactRaycastLayer;

    public event Action Pushed;

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
                if (hit.collider.gameObject.GetComponent<Cube>())
                {
                    Pushed?.Invoke();
                    hit.collider.gameObject.GetComponent<Cube>().DestroyCube();
                }

            }
        }
    }
}
