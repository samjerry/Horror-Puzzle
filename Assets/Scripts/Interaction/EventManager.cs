using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EventManager : MonoBehaviour
{
    public enum EventType
    { 
        Light, 
        Move, 
        Unlock, 
        Audio 
    }

    public EventType eType;

    private Light _light;

    /// <summary>
    /// Universal Event
    /// </summary>
    public bool isTriggered;

    /// <summary>
    /// Audio Event
    /// </summary>
    public AudioClip audio;

    /// <summary>
    /// Move Event
    /// </summary>
    public Vector3 targetPos;
    public float moveSpd;


    void Start()
    {
        if (eType == EventType.Light)
        {
            _light = transform.GetChild(0).GetComponent<Light>();
        }
    }

    public void ToggleLight()
    {
        isTriggered = !isTriggered;
        _light.enabled = !_light.enabled;
    }

    public void MoveObject()
    {
        isTriggered = !isTriggered;
        Debug.Log("Initiate MoveObject() on " + this.gameObject.name + " from " + transform.position + " to " + targetPos + " with speed " + moveSpd);
        while (transform.position != targetPos)
        {
            transform.position = Vector3.Lerp(transform.position, targetPos, Time.deltaTime * moveSpd);
        }
    }
}