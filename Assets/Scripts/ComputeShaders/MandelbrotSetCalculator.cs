using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Vector2 = UnityEngine.Vector2;

public class MandelbrotSetCalculator
{
    private MandelbrotSetSpace _mandelbrotSetSpace;
    
    public void Init(MandelbrotSetSpace space)
    {
        _mandelbrotSetSpace = space;
    }
    
    public IEnumerable<Point> EvaluateMandelbrotSet()
    {
        var points = new List<Point>();

        for (int y = 0; y < Screen.height; y++)
        {
            for (int x = 0; x < Screen.width; x++)
            {
                Vector2 coordinates = _mandelbrotSetSpace.ConvertPixelPositionToCoordinates(x, y);

                if (CheckIfPointInMandelbrotSet(coordinates.x, coordinates.y))
                {
                    points.Add(new Point(x, y));
                }
            }
        }

        return points;
    }

    private bool CheckIfPointInMandelbrotSet(float x, float y)
    {
        const int iterations = 100;
        int iterationsForPoint = 0;
        
        var z = new Complex(0, 0);

        for (int i = 0; i < iterations && Complex.Abs(z) < 2; i++)
        {
            z = z * z + new Complex(x, y);
            ++iterationsForPoint;
        }


        return iterations == iterationsForPoint;
    }
}