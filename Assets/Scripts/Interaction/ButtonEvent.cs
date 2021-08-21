using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ButtonEvent : MonoBehaviour
{
    public UnityEvent ButtonEventHandler;

    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.T) && gameObject.name == "Lights")
        {
            InvokeEvent();
        }
    }

    public void InvokeEvent()
    {
        ButtonEventHandler.Invoke();
    }
}