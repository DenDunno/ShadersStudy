using System.Collections;
using UnityEngine;

public class MandelbrotSet : MonoBehaviour
{
    [SerializeField] private MandelbrotSetRenderer _mandelbrotSetRenderer;
    [SerializeField] private MandelbrotSetSpace _mandelbrotSetSpace;
    private readonly MandelbrotSetCalculator _mandelbrotSetCalculator = new MandelbrotSetCalculator();

    private void Start()
    {
        _mandelbrotSetRenderer.Init();
        _mandelbrotSetSpace.Init();
        _mandelbrotSetCalculator.Init(_mandelbrotSetSpace);
    }

    public void Draw()
    {
        var points = _mandelbrotSetCalculator.EvaluateMandelbrotSet();
        _mandelbrotSetRenderer.Draw(points, Color.white);
    }
}