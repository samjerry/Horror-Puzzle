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

    void Start()
    {
        _pMovement = MovementTypes.walk;
        SetSpeed(_pMovement.ToString());
    }

    void Update()
    {
        if (Input.GetAxis("Vertical") > 0)
        {
            var a = transform.TransformDirection(0, 0, 50);
            transform.position += a * _spd;
        }
        if (Input.GetAxis("Vertical") < 0)
        {
            var b = transform.TransformDirection(0, 50, 0);
            transform.position += b * _spd;
        }
        if (Input.GetAxis("Horizontal") > 0)
        {
            var c = transform.TransformDirection(50, 0, 0);
            transform.position += c * _spd;
        }
        if (Input.GetAxis("Horizontal") < 0)
        {
            var d = transform.TransformDirection(-50, 0, 0);
            transform.position += d * _spd;
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
