using UnityEngine;

public class ObjectInitialization : MonoBehaviour
{
    [SerializeField] private int _scaleDivider;

    public void Initialise(Vector3 scale)
    {
        transform.localScale = SetScale(scale);
        GetComponent<Renderer>().material.color = GenerateColor();
    }

    private Vector3 SetScale(Vector3 scale)
    {
        return new Vector3(scale.x / _scaleDivider, scale.y / _scaleDivider, scale.z / _scaleDivider);
    }

    private Color GenerateColor()
    {
        return Random.ColorHSV();
    }
}
