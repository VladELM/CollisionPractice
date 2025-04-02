using System;
using UnityEngine;

public class Cube : MonoBehaviour
{
    [SerializeField] private int _scaleDivider;
    [SerializeField] private int _chanceDivider;
    [SerializeField] private string _cameraName;

    private InputReader _inputReading;
    private int _maxChance = 100;
    private int _currentMaxChance;

    public event Action Spawning;

    public Vector3 Position => transform.position;
    public Vector3 Scale => transform.localScale;
    public int MaxChance => _maxChance;
    public int CurrentMaxChance => _currentMaxChance;

    public void Initialise(Vector3 scale)
    {
        transform.localScale = new Vector3(scale.x / _scaleDivider, scale.y / _scaleDivider, scale.z / _scaleDivider);
        GetComponent<Renderer>().material.color = UnityEngine.Random.ColorHSV(); ;
    }

    public void DestroyCube()
    {
        Spawning?.Invoke();
        Destroy(gameObject);
    }

    private void OnEnable()
    {
        _inputReading = GameObject.Find(_cameraName).GetComponent<InputReader>();
        _inputReading.Pushed += ReduceChance;
        _currentMaxChance = _maxChance;
    }

    private void OnDisable()
    {
        _inputReading.Pushed -= ReduceChance;
    }

    private void ReduceChance()
    {
        _currentMaxChance /= _chanceDivider;
    }
}
