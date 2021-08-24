using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact : MonoBehaviour
{
    private InteractionCheck _interactCheck;
    // Start is called before the first frame update
    void Start()
    {
        _interactCheck = GetComponent<InteractionCheck>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && _interactCheck.target != null)
        {
            _interactCheck.target.GetComponent<TriggerEvent>().InvokeEvent();
        }
    }
}