using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum MovementTypes { walk, run, crouch};

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] MovementTypes _pMovement;

    [SerializeField] float _walkSpd = 1;
    [SerializeField] float _crouchSpd = 0.5f;
    [SerializeField] float _runSpd = 1.5f;
    float _spd;

    Vector3 _dir;

    void Start()
    {
        _pMovement = MovementTypes.walk;
        SetSpeed(_pMovement.ToString());
    }

    void Update()
    {
        if (Input.GetAxis("Vertical") > 0)
        {
            _dir = transform.TransformDirection(0, 0, 50);
            transform.position += _dir * _spd;
        }
        if (Input.GetAxis("Vertical") < 0)
        {
            _dir = transform.TransformDirection(0, 50, 0);
            transform.position += _dir * _spd;
        }
        if (Input.GetAxis("Horizontal") > 0)
        {
            _dir = transform.TransformDirection(50, 0, 0);
            transform.position += _dir * _spd;
        }
        if (Input.GetAxis("Horizontal") < 0)
        {
            _dir = transform.TransformDirection(-50, 0, 0);
            transform.position += _dir * _spd;
        }
    }

    void SetSpeed(string _moveType)
    {
        switch (_moveType)
        {
            case "walk":
                _spd = _walkSpd;
                break;
            case "run":
                _spd = _runSpd;
                break;
            case "crouch":
                _spd = _crouchSpd;
                break;

            default:
                break;
        }
    }
}
