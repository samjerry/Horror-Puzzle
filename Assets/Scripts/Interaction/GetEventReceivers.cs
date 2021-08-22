using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class GetEventReceivers : MonoBehaviour
{
    public GameObject[] eventReceivers;
    private ButtonEvent _interactable;

    void Start()
    {
        _interactable = GetComponent<ButtonEvent>();
        int listenerCount = _interactable.ButtonEventHandler.GetPersistentEventCount();

        eventReceivers = new GameObject[listenerCount];

        for (int i = 0; i < listenerCount; i++)
        {
            eventReceivers[i] = GameObject.Find(_interactable.ButtonEventHandler.GetPersistentTarget(i).name);
            Debug.Log(eventReceivers[i]);
        }
    }
}