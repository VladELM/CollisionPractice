using UnityEngine;

public class Selecting : MonoBehaviour
{
    [SerializeField] private InputReading _inputReading;
    [SerializeField] private Material _selectedMaterial;
    [SerializeField] private Material _unselectedMaterial;

    private void OnEnable()
    {
        _inputReading.Selected += ChangeColorToSelect;
        _inputReading.Deselected += ChangeColorToDeselect;
    }

    private void OnDisable()
    {
        _inputReading.Selected -= ChangeColorToSelect;
        _inputReading.Selected -= ChangeColorToDeselect;
    }

    private void ChangeColorToSelect()
    {
        GetComponent<Renderer>().material = _selectedMaterial;
    }

    private void ChangeColorToDeselect()
    {
        GetComponent<Renderer>().material = _unselectedMaterial;
    }
}
