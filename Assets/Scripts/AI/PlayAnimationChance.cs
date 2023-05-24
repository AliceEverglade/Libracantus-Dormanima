using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAnimationChance : BehaviorAction
{
    public override void Action(CreatureData self, CreatureData.AnimationStates animation, float chance)
    {
        if(Random.Range(1,100) <= chance)
        {
            self.AnimState = animation;
        }
    }
}
