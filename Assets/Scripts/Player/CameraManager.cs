using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    [SerializeField] private PlayerMovement _pMovement;

    [SerializeField] private GameObject _target;
    [SerializeField] private float _yOffset;

    [SerializeField] private float _sensitivityX = 100F;
    [SerializeField] private float _sensitivityY = 100F;

    [SerializeField] private float _minimumX = -90F;
    [SerializeField] private float _maximumX = 90F;

    [SerializeField] private float _xRot;
    [SerializeField] private float _yRot;

    [SerializeField] private Transform _headPos;
    [SerializeField] private Transform _crouchPos;

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

        if (transform.position != _headPos.position && _pMovement.pMoveType != "crouch")
        {
            transform.position = _headPos.position;
        }

        if (_pMovement.pMoveType == "crouch" && transform.position != _crouchPos.position)
        {
            transform.position = _crouchPos.position;
        }

    }
}
