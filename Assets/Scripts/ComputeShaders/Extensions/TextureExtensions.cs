using UnityEngine;

public static class TextureExtensions
{
    public static void FillWithColor(this Texture2D texture, Color color)
    {
        for (int i = 0; i < texture.width; ++i)
        {
            for (int j = 0; j < texture.height; j++)
            {
                texture.SetPixel(i, j, color);
            }   
        }
        
        texture.Apply();
    }
}