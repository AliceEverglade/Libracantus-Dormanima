using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Data/Recolor")]
public class RecolorData : DataSO
{
    [Header("Content")]
    public Texture2D Input;
    public Material Output;
    public List<Color> Colors;

}
