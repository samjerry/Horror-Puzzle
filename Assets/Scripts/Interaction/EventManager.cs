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
    public bool ReverseAble;

    /// <summary>
    /// Audio Event
    /// </summary>
    public AudioClip audio;

    /// <summary>
    /// Move Event
    /// </summary>
    public Vector3 targetPos;
    public float moveSpd;
    private float _margin = 0.2f;


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

        StartCoroutine(LerpPosition(targetPos, 3));
    }

    IEnumerator LerpPosition(Vector3 targetPosition, float duration)
    {
        float time = 0;
        Vector3 startPosition = transform.position;

        while (time < duration)
        {
            transform.position = Vector3.Lerp(startPosition, targetPosition, time / duration);
            time += Time.deltaTime;
            yield return null;
        }
        transform.position = targetPosition;
    }
}