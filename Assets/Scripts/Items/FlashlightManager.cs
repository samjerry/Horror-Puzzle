using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashlightManager : MonoBehaviour
{
    private bool _isHeld;

    [SerializeField] private GameObject _lightSource;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && _isHeld && _lightSource.active)
        {
            _lightSource.SetActive(false);
        } 
        
        else if (Input.GetKeyDown(KeyCode.F) && _isHeld && !_lightSource.active)
        {
            _lightSource.SetActive(false);
        }
    }
}
