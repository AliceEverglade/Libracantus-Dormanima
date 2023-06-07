using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;

public abstract class CreatureData : ScriptableObject
{
    [Header("Base")]
    public string CreatureName;
    public GameObject Prefab;
    public GameObject CreatureReference;

    [Header("AI")]
    [SerializeField] private CreatureBehavior currentBehavior;
    public CreatureBehavior CurrentBehavior
    {
        get
        {
            return currentBehavior;
        }
        set
        {
            if (currentBehavior != value)
            {
                ActDelayCounter = 0;
                currentBehavior = value;
            }
        }
    }
    public List<BehaviorData> Behaviors;
    public float ActDelayCounter;
    [Range(0,10)]
    public float AISpeed; // won't do anything when it's 0

    

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
        IdleAction1,
        Walk,
        Hang,
        LayDown,
    }

    public enum BehaviorStates
    {
        Wander,
        GoTo,
        Idle,
        Grabbed,

    }
    


    #endregion

    public abstract void SetData();

    public void Spawn(Vector3 pos)
    {
        CreatureReference = Instantiate(Prefab,pos, Quaternion.identity);
        currentBehavior = Behaviors[0].Behavior;
        SetData();
    }
    public void ActivateBehavior()
    {
        CurrentBehavior.Act(this);
    }
}

[Serializable]
public class BehaviorData
{
    public CreatureData.BehaviorStates BehaviorState;
    public CreatureBehavior Behavior;
}
