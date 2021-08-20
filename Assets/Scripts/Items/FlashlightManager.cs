using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashlightManager : MonoBehaviour
{
    private bool _isHeld = true;

    [SerializeField] private GameObject _lightSource;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && _isHeld)
        {
            _lightSource.GetComponent<Light>().enabled = !_lightSource.GetComponent<Light>().enabled;
        }
    }
}
