using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatureBehaviorManager : MonoBehaviour
{
    public CreatureData data;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (data.CurrentBehavior.IsReadyToAct(data) && data.AnimState != CreatureData.AnimationStates.Hang)
        {
            data.ActivateBehavior();
        }
    }
}
