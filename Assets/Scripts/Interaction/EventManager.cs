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
    public AudioSource audio;

    /// <summary>
    /// Move Event
    /// </summary>
    private Vector3 _curPos;
    public Vector3 targetPos;


    void Start()
    {
        _light = transform.GetChild(0).GetComponent<Light>();
        _curPos = transform.position;
    }

    public void ToggleLight() => _light.enabled = !_light.enabled;
   
}