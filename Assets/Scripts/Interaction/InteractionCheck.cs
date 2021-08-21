using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionCheck : MonoBehaviour
{
    public GameObject target;

    [SerializeField]
    private float maxDistance = 0.8f;

    private Vector3 direction;

    private GameObject rayCam;
    private GameObject interactUI;

    private RaycastHit hit;
    private LayerMask interactablesLayer;

    private void Start()
    {
        rayCam = transform.Find("Main Camera").gameObject;
        //interactUI = GameObject.Find("PlayerUICanvas");
        interactablesLayer = LayerMask.GetMask("Interactables");
    }

    void FixedUpdate()
    {
        Vector3 origin = rayCam.transform.position;
        Vector3 direction = rayCam.transform.forward;

        Debug.DrawRay(origin, direction * maxDistance, Color.red);
        Ray ray = new Ray(origin, direction);

        if (Physics.Raycast(ray, out RaycastHit raycastHit, maxDistance, interactablesLayer))
        {
            if (target != raycastHit.transform.gameObject)
            {
                print("collision with: " + raycastHit.transform.name);
                target = raycastHit.transform.gameObject;
            }
        }

        else
        {
            target = null;
        }


        //if (hit.transform.gameObject.layer == LayerMask.GetMask("Interactables") && !interactUI.GetComponent<InteractHoverUI>().isInteractable)
        //{
        //    Debug.Log("Hit Interactable");
        //    interactUI.GetComponent<InteractHoverUI>().OnToggleHover();
        //    interactUI.GetComponent<InteractHoverUI>().isInteractable = true;
        //}

        //else if (hit.transform.gameObject.layer != LayerMask.GetMask("Interactables") && interactUI.GetComponent<InteractHoverUI>().isInteractable)
        //{
        //    interactUI.GetComponent<InteractHoverUI>().OnToggleHover();
        //    interactUI.GetComponent<InteractHoverUI>().isInteractable = false;
        //}


    }
}