using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ButtonEvent : MonoBehaviour
{
    public UnityEvent triggerEventHandler;

    public void InvokeEvent()
    {
        triggerEventHandler.Invoke();
    }
}