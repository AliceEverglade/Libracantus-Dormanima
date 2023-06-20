using System.Collections;
using System.Collections.Generic;
using Unity.AI.Navigation;
using UnityEngine;
using UnityEngine.UI;

public class SpawnCube : MonoBehaviour
{
    [SerializeField] GameObject prefab;
    [SerializeField] float maxScale;
    [SerializeField] GameObject target;
    [SerializeField] Slider xSlider;
    [SerializeField] Slider ySlider;
    [SerializeField] Slider zSlider;
    [SerializeField] NavigationBaker baker;
    // Start is called before the first frame update
    void Start()
    {
        xSlider.maxValue = maxScale; 
        ySlider.maxValue = maxScale;
        zSlider.maxValue = maxScale; 
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Spawn()
    {
        GameObject cube = Instantiate(prefab, target.transform.position,Quaternion.identity);
        cube.transform.localScale = new Vector3(xSlider.value, ySlider.value, zSlider.value);
        baker.surfaces.Add(cube.GetComponent<NavMeshSurface>());
    }
}
