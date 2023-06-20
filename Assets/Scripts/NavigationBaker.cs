using System;
using System.Collections;
using System.Collections.Generic;
using Unity.AI.Navigation;
using UnityEngine;
using UnityEngine.AI;

public class NavigationBaker : MonoBehaviour
{

    public List<NavMeshSurface> surfaces;
    

    // Use this for initialization
    void Update()
    {

    }

    public void BakeNavMesh()
    {
        foreach (NavMeshSurface surface in surfaces)
        {
            surface.BuildNavMesh();
        }
    }

}
