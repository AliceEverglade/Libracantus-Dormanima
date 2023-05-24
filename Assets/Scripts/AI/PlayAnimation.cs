using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "AI/Actions/PlayAnimation")]
public class PlayAnimation : BehaviorAction
{
    public override void Action(CreatureData self, CreatureData.AnimationStates animation)
    {
        self.AnimState = animation;
    }
}
