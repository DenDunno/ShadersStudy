using UnityEngine;


public class CameraZoom : MonoBehaviour
{
    private readonly float _zoomSpeed = 0.25f;

    public float Zoom { get; private set; } = 4f;

    private void Update()
    {
        if (Input.touchCount == 2)
        {
            float zoomCoefficient = GetZoomCoefficient();
            SetZoom(zoomCoefficient);
        }
    }
    
    private float GetZoomCoefficient()
    {
        Touch firstTouch = Input.GetTouch(0);
        Touch secondTouch = Input.GetTouch(1);

        Vector2 previousFirstTouchPosition = firstTouch.GetPreviousTouchPosition();
        Vector2 previousSecondTouchPosition = secondTouch.GetPreviousTouchPosition();

        float previousDelta = GetDiffInMagnitude(previousFirstTouchPosition, previousSecondTouchPosition);
        float currentDelta = GetDiffInMagnitude(firstTouch.position, secondTouch.position);

        return previousDelta - currentDelta;
    }

    private float GetDiffInMagnitude(Vector2 first, Vector2 second)
    {
        return (first - second).magnitude;
    }
    
    private void SetZoom(float zoomCoefficient)
    {
        Zoom += zoomCoefficient * _zoomSpeed * Time.deltaTime;
        Debug.Log(Zoom);
    }
}