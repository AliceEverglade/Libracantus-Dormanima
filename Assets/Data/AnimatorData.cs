using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Data/AnimatorData")]
public class AnimatorData : ScriptableObject
{
    [TextArea(4, 4)]
    public string description;

    public Animator Animator;

    public Avatar Armature;

    public List<AnimationDict> Animations;

    public Animation GetAnimation(CreatureData.AnimationStates state)
    {
        foreach (AnimationDict a in Animations)
        {
            if (a.State == state)
            {
                return a.Animation;
            }
        }
        return null;
    }
}

[Serializable]
public class AnimationDict
{
    public CreatureData.AnimationStates State;
    public Animation Animation;
}
