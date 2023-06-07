using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecolorData
{
    public Texture2D InputTexture;
    public Material OutputMaterial;
    public Color[] Colors;

    public void CreateMaterial()
    {
        CreatePaletteTexture();

    }

    private Texture2D CreatePaletteTexture()
    {
        Texture2D paletteTex = new Texture2D(Colors.Length, 1, UnityEngine.Experimental.Rendering.GraphicsFormat.R32G32B32A32_UInt, 0);
        paletteTex.SetPixels(Colors);
        paletteTex.Apply();

        return paletteTex;
    }
}
