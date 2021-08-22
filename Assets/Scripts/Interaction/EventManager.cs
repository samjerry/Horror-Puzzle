using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum EventType { Light, Move, Unlock, Audio }
public class EventManager : MonoBehaviour
{
    [SerializeField] EventType _eType;

    private Light _light;

    private Transform _curPos;

    void Start()
    {
        _light = transform.GetChild(0).GetComponent<Light>();
    }

    public void ToggleLight()
    {
        /*
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
        */
    }
}