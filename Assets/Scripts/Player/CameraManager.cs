using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    [SerializeField] GameObject _target;
    [SerializeField] float _yOffset;

    Quaternion _oldRot;
    Vector3 _oldPos;

    void Start()
    {
        SetTransform();
    }

    private void Update()
    {
        if (transform.position != _oldPos)
        {
            SetTransform();
        }

        if (transform.rotation != _oldRot)
        {
            SetTransform();
        }
    }

    void SetTransform()
    {
        transform.position = new Vector3(_target.transform.position.x, _target.transform.position.y + _yOffset, _target.transform.position.z);
        transform.rotation = _target.transform.rotation;
    }
}
