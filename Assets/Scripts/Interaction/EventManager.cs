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

    public AudioSource audio;

    private Vector3 _curPos;
    public Vector3 targetPos;

    public bool isTriggered;

    void Start()
    {
        _light = transform.GetChild(0).GetComponent<Light>();
        _curPos = transform.position;
    }

    public void ToggleLight() => _light.enabled = !_light.enabled;
    /*
    {
        if (_light.intensity == 1f)
        {
            Debug.Log("off");
            _light.intensity = 0;
        }
        else
        {
            Debug.Log("on");
            _light.intensity = 1;
        } 
    }
    */
}