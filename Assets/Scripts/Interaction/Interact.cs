using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact : MonoBehaviour
{
    private InteractionCheck interactCheck;
    // Start is called before the first frame update
    void Start()
    {
        interactCheck = GetComponent<InteractionCheck>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && interactCheck.target != null)
        {
            interactCheck.target.GetComponent<ButtonEvent>().InvokeEvent();
        }
    }
}