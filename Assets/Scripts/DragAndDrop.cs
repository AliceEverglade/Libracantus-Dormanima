using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndDrop : MonoBehaviour
{
    [SerializeField] private Vector3 mousePos;
    private Camera cam;
    [SerializeField] private string cameraName;
    private CreatureData data;
    // Start is called before the first frame update
    void Start()
    {
        cam = GameObject.Find(cameraName).GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private Vector3 GetMousePos()
    {
        return cam.WorldToScreenPoint(transform.position);
    }

    private void OnMouseDown()
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if(Physics.Raycast(ray, out hit,100))
        {
            if(hit.collider.gameObject.GetComponent<CreatureBehaviorManager>())
            {
                data = hit.collider.gameObject.GetComponent<CreatureBehaviorManager>().data;
                data.AnimState = CreatureData.AnimationStates.Hang;
                mousePos = Input.mousePosition - GetMousePos();
            }
            if (hit.collider.gameObject.CompareTag("Movable"))
            {
                mousePos = Input.mousePosition - GetMousePos();
            }
        }
    }
    private void OnMouseUp()
    {
        if(GetComponent<CreatureBehaviorManager>() != null)
        {
            data.AnimState = CreatureData.AnimationStates.Idle;
        }
        
    }
    private void OnMouseDrag()
    {
        transform.position = transform.position = cam.ScreenToWorldPoint(Input.mousePosition - mousePos);
    }
}
