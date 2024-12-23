using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractSystem : MonoBehaviour
{
    [SerializeField] private Camera plCamera;
    [SerializeField] private LayerMask layer;
    [SerializeField] private Text interactionText;

    public float interactDist;
    
    void Start()
    {
        
    }


    void Update()
    {
        Ray ray = new Ray(plCamera.transform.position, plCamera.transform.forward);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, interactDist, layer))
        {
            if (hit.collider.TryGetComponent(out IInteractable interactable))
            {
                Debug.Log(hit.collider.name + " -  " + hit.distance);
                interactionText.gameObject.SetActive(true);
                interactionText.text = interactable.Message;
                if (Input.GetKeyDown(KeyCode.E))
                {
                    interactable.Interact();
                }
            }
        }
        else
        {
            interactionText.gameObject.SetActive(false);
        }
    }

    //private void OnDrawGizmos(){
    //    Ray ray = new Ray(plCamera.transform.position, plCamera.transform.forward);
    //    Gizmos.DrawLine(ray.origin, ray.direction);
    //}
}
