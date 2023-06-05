using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class GameStates : MonoBehaviour
{
    [SerializeField] private List<GameState> GameStateList;
    [SerializeField] private StateNames stateName;
    public StateNames StateName
    {
        get => stateName;
        set
        {
            if (stateName != value)
            {
                SetState(value);
                stateName = value;
            }
        }
    }
    public enum StateNames
    {
        Scan,
        Play,
        Pause,
        Shop
    }

    public void SetState(StateNames state)
    {
        foreach(GameState gs in GameStateList)
        {
            gs.SetProperties(false);
        }
        foreach(GameState gs in GameStateList)
        {
            if(gs.State == state)
            {
                gs.SetProperties(true);
            }
        }
    }
}

[Serializable]
public class GameState
{
    public string Name;
    public GameStates.StateNames State;
    public List<GameObject> ObjectProperties;
    public List<Behaviour> ScriptProperties;

    public void SetProperties(bool on)
    {
        foreach(GameObject obj in ObjectProperties)
        {
            obj.SetActive(on);
        }
        foreach(Behaviour script in ScriptProperties)
        {
            script.enabled = on;
        }
    }
}
