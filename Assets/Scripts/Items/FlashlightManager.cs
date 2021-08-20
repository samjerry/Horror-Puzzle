using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashlightManager : MonoBehaviour
{
    private bool _isHeld;

    [SerializeField] private Light _lightSource;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && _isHeld)
        {

        }
    }

    private void Toggle()
    {

    }
}
