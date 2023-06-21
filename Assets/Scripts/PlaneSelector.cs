using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneSelector : MonoBehaviour
{
    [SerializeField] private Material baseMaterial;
    [SerializeField] private Material selectedMaterial;
    private Camera cam;
    [SerializeField] private string cameraName;
    [SerializeField] private List<GameObject> selectedPlanes;

    private void Start()
    {
        cam = GameObject.Find(cameraName).GetComponent<Camera>();
    }

    private void OnMouseDown()
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 100))
        {
            if (hit.collider.gameObject.CompareTag("ARPlane"))
            {
                if(hit.collider.gameObject.GetComponent<MeshRenderer>().material == baseMaterial)
                {
                    selectedPlanes.Add(hit.collider.gameObject);
                    hit.collider.gameObject.GetComponent<MeshRenderer>().material = selectedMaterial;
                }
                if (hit.collider.gameObject.GetComponent<MeshRenderer>().material == selectedMaterial)
                {
                    selectedPlanes.Remove(hit.collider.gameObject);
                    hit.collider.gameObject.GetComponent<MeshRenderer>().material = baseMaterial;
                }
                
            }
        }
    }

}
