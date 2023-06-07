using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CreatureBehavior : ScriptableObject
{
    public List<BehaviorAction> Actions;
    public float ActDelay;

    public virtual void Act(CreatureData self) 
    {
        Debug.LogWarning("this behavior does not have a matching Act() method");
    }

    public bool IsReadyToAct(CreatureData self)
    {
        if (self.AISpeed == 0)
        {
            return false;
        }
        if (self.ActDelayCounter <= 0)
        {
            self.ActDelayCounter = (1 / self.AISpeed) * ActDelay;
            return true;
        }
        else
        {
            self.ActDelayCounter -= Time.deltaTime;
            return false;
        }
    }
}
