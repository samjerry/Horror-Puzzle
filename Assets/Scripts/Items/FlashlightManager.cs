using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashlightManager : MonoBehaviour
{
    [SerializeField] EventManager _eManager;

    private bool _isHeld = true;

    [SerializeField] private GameObject _lightSource;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && _isHeld)
        {
            _eManager.ToggleLight();
        }
    }
}
