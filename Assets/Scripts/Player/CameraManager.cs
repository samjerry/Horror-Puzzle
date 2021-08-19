using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    [SerializeField] GameObject _target;
    [SerializeField] float _heightOffset;

    void Start()
    {
        transform.position = new Vector3(_target.transform.position.x, _target.transform.position.y + _heightOffset, _target.transform.position.z);
        transform.rotation = _target.transform.rotation;
    }
}
