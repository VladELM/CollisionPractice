using System;
using UnityEngine;

public class InputReading : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private float _rayLength;
    //[SerializeField] private ObjectsCreating _objectsCreating;

    public event Action Selected;
    public event Action Deselected;
    private Selecting _currentSelected;

    private void Update()
    {
        CastRay();
    }

    private void CastRay()
    {
        Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(ray.origin, ray.direction * _rayLength, Color.red);

        SelectObjects(ray);
        ReadMouseClick(ray);
    }

    private void SelectObjects(Ray ray)
    {
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.gameObject.GetComponent<Selecting>())
                _currentSelected = hit.collider.gameObject.GetComponent<Selecting>();

            if (_currentSelected)
            {
                if (_currentSelected && _currentSelected != hit.collider.gameObject.GetComponent<Selecting>())
                    Deselected?.Invoke();
                else
                    Selected?.Invoke();
            }
        }
    }

    private void ReadMouseClick(Ray ray)
    {
        RaycastHit hit;

        if (Input.GetMouseButton(0))
        {
            if (Physics.Raycast(ray, out hit))
            {
                //if (hit.collider.gameObject.GetComponent<ObjectsCreating>())
                    //_objectsCreating.CreateObjects(hit.transform.position);
            }
        }
    }
}
