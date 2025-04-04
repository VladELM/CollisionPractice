using UnityEngine;

public class InputReader : MonoBehaviour
{
    public delegate void Message(Vector3 position);
    public event Message Pushed;

    private void Update()
    {
        ReadMouseClick();
    }

    private void ReadMouseClick()
    {
        if (Input.GetMouseButtonDown(0))
            Pushed?.Invoke(Input.mousePosition);
    }
}
