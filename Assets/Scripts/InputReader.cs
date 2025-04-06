using UnityEngine;

public class InputReader : MonoBehaviour
{
    [SerializeField] public int _buttonValue;

    public delegate void Message(Vector3 position);
    public event Message Pushed;

    private void Update()
    {
        if (Input.GetMouseButtonDown(_buttonValue))
            Pushed?.Invoke(Input.mousePosition);
    }
}
