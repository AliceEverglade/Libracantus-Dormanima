using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[CreateAssetMenu(menuName ="Data/CreatureData/Aetherian")]
public class AetherianData : CreatureData
{
    [Header("Statistics")]
    public float Speed;

    public override void SetData()
    {
        CreatureReference.GetComponent<NavMeshAgent>().speed = Speed;
        CreatureReference.GetComponent<NavMeshAgent>().acceleration = Speed * 3;
    }

    
}
