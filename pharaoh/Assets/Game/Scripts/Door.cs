using UnityEngine;
using UnityEditor;

public class Door : MonoBehaviour
{

    private BoxCollider2D _boxCollider;
    private MeshRenderer _meshRenderer;
    private int _activePlates = 0;

    [Tooltip("An inverted door means an active pressure plate will close it.")]
    public bool inverted = false;

    private void Awake()
    {
        _boxCollider = GetComponent<BoxCollider2D>();
        _meshRenderer = transform.Find("Skin").GetComponent<MeshRenderer>();

        RefreshState();
    }
    
    // Called when a pressure plate is pressed
    public void Open()
    {
        _activePlates++;

        RefreshState();
    }

    // Called when a pressure plate is released
    public void Close()
    {
        _activePlates--;

        RefreshState();
    }

    // Refreshes the state of the door, whether it is open or not
    private void RefreshState()
    {
        _boxCollider.enabled = !IsOpen();
        _meshRenderer.enabled = !IsOpen();
    }

    // Returns whether the door is open or not
    // The door is opened when 1 pressure plate or more are pressed
    // If inverted, the door is openede when 0 pressure plate are pressed
    public bool IsOpen()
    {
        if (!inverted)
            return _activePlates > 0;
        else
            return _activePlates < 1;
    }

    private void OnDrawGizmos()
    {
        GUIStyle style = new GUIStyle();
        style.normal.textColor = IsOpen() ? Color.green : Color.red;
        Handles.Label(transform.position, IsOpen() ? "Opened" : "Closed", style);
    }

}
