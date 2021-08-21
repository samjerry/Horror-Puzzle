using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    [SerializeField]
    private GameObject _target;
    private bool isOn = false;


    private void Update()
    {
        if (isOn)
        {
            ToggleTarget();
        }
    }

    private void ToggleTarget()
    {
        //target.interactable.toggle;
    }
}