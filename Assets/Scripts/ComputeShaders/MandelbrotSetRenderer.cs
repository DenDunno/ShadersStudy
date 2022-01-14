using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MandelbrotSetRenderer : MonoBehaviour
{
    [SerializeField] private RawImage _rawImage;
    private Texture2D _texture;
    
    public void Init()
    {
        _texture = new Texture2D(Screen.width, Screen.height);
        _texture.FillWithColor(Color.black);
        _rawImage.texture = _texture;
    }

    public void Draw(IEnumerable<Point> pointsToBeRendered, Color color)
    {
        foreach (Point point in pointsToBeRendered)
        {
            _texture.SetPixel(point.X, point.Y, color);
        }
        
        _texture.Apply();
    }
}