using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum TriggerTypes { Button, Area, Amount}
public class EventTrigger : MonoBehaviour
{
    [SerializeField] TriggerTypes _trigger;

    [SerializeField] private int _amount = 0;

    [SerializeField] private float _range;

    [SerializeField] private bool _isTriggered = false;

    [SerializeField] List<GameObject> _triggerObjects;
    

}
