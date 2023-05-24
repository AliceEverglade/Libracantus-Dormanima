using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct WeightedPos
{
    public WeightedPos(Vector3 pos, float weight)
    {
        Pos = pos;
        Weight = weight;
    }
    public Vector3 Pos { get; }
    public float Weight { get; }
}

public struct WeightedAnimation
{
    public WeightedAnimation(CreatureData.AnimationStates animation, float weight)
    {
        Animation = animation;
        Weight = weight;
    }
    public CreatureData.AnimationStates Animation { get; }
    public float Weight { get; }
}


public class Struct
{
    
}
