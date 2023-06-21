using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

[Serializable]
public class GameStates : MonoBehaviour
{
    [SerializeField] private GameState state;

    [SerializeField] private ARPlaneManager planeManager;
    [SerializeField] private PlaneSelector planeSelector;
    [SerializeField] private GameObject scanUI;
    [SerializeField] private GameObject playUI;
    public GameState State
    {
        get => state;
        set
        {
            if (state != value)
            {
                switch (value)
                {
                    case GameState.Scan:
                        setScanState();
                        break;
                    case GameState.Play:
                        SetPlayState();
                        break;
                }
                state = value;
            }
        }
    }
    public enum GameState
    {
        Scan,
        Play
    }

    private void Start()
    {
        setScanState();
    }

    public void SetPlayState()
    {
        planeManager.enabled = false;
        scanUI.SetActive(false);
        playUI.SetActive(true);
    }

    public void setScanState()
    {
        planeManager.enabled = true;
        scanUI.SetActive(true);
        playUI.SetActive(false);
    }
    
}
