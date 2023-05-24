using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public abstract class CreatureData : ScriptableObject
{
    [Header("Base")]
    public string CreatureName;
    public GameObject Prefab;
    public GameObject CreatureReference;

    [Header("AI")]
    public List<CreatureBehavior> Behaviors;
    public float ActDelayCounter;
    [Range(0,10)]
    public float AISpeed; // won't do anything when it's 0

    private CreatureBehavior currentBehavior;
    public CreatureBehavior CurrentBehavior
    {
        get
        {
            return currentBehavior;
        }
        set
        {
            if(currentBehavior != value)
            {
                ActDelayCounter = 0;
                currentBehavior = value;
            }
        }
    }

    [Header("ComponentReferences")]
    public AnimatorData animData;
    
    private AnimationStates animState = AnimationStates.Idle;
    public AnimationStates AnimState
    {
        get
        {
            return animState;
        }
        set
        {
            if (value != animState)
            {
                if(animData.Animator != null)
                {
                    animData.Animator.Play(value.ToString());
                }
                animState = value;
            }
        }
    }

    #region Enums
    public enum AnimationStates
    {
        Idle,
        Walk,
        Hang,
        LayDown,
    }
    


    #endregion

    public abstract void SetData();

    public void Spawn(Vector3 pos)
    {
        CreatureReference = Instantiate(Prefab,pos, Quaternion.identity);
        SetData();
    }
    public void ActivateBehavior()
    {
        CurrentBehavior.Act(this);
    }
}
