using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    [SerializeField] GameObject _target;
    [SerializeField] float _yOffset;

    [SerializeField] float _sensitivityX = 100F;
    [SerializeField] float _sensitivityY = 100F;

    [SerializeField] float _minimumX = -90F;
    [SerializeField] float _maximumX = 90F;

    [SerializeField] float _xRot;
    [SerializeField] float _yRot;


    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;    
    }

    private void Update()
    {
        /// <summary>
        ///  Mouse Input
        /// <summary>
        /// 
        float _mouseX = Input.GetAxis("Mouse X") * _sensitivityX * Time.deltaTime;
        float _mouseY = Input.GetAxis("Mouse Y") * _sensitivityY * Time.deltaTime;

        _xRot -= _mouseY;
        _xRot = Mathf.Clamp(_xRot, _minimumX, _maximumX);

        transform.localRotation = Quaternion.Euler(_xRot, 0f, 0f);
        _target.transform.Rotate(Vector3.up * _mouseX);

    }
}
