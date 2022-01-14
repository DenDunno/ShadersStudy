using System;
using UnityEngine;

[Serializable]
public class MandelbrotSetSpace 
{
    [SerializeField] private CameraPanning _cameraPanning;
    [SerializeField] private CameraZoom _cameraZoom;

    private Vector2 _staticOffset;

    public void Init()
    {
        _staticOffset = new Vector2(3 * Screen.width / 4f, Screen.height / 2f);
    }
    
    public Vector2 ConvertPixelPositionToCoordinates(int x, int y)
    {
        float zoom = Screen.width / _cameraZoom.Zoom;

        float xCoordinate = (x - _staticOffset.x + _cameraPanning.Offset.x) / zoom;
        float yCoordinate = (y - _staticOffset.y + _cameraPanning.Offset.y) / zoom;

        return new Vector2(xCoordinate, yCoordinate);
    }
}