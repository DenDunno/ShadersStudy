using UnityEngine;


public class CameraPanning : MonoBehaviour
{
    [SerializeField] private Camera _mainCamera;

    private Vector2 _touchStartPosition;
    private bool _isUserZooming;

    public Vector2 Offset { get; private set; }
    
    private void Update()
    {
        if (Input.touchCount > 1)
        {
            _isUserZooming = true;
            return;
        }

        if (Input.GetMouseButton(0))
        {
            MoveCamera();
        }
    }

    private void MoveCamera()
    {
        Vector2 worldTouchPosition = _mainCamera.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetMouseButtonDown(0) || _isUserZooming)
        {
            _isUserZooming = false;
            _touchStartPosition = worldTouchPosition;
        }

        Offset += _touchStartPosition - worldTouchPosition;
        Debug.Log(Offset);
    }
}