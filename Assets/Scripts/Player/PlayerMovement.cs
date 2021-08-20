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
    [SerializeField] float _spd;

    bool _isGrounded;

    Vector3 _pos;

    void Start()
    {
        _pos = transform.position;
        _pMovement = MovementTypes.walk;

        SetSpeed(_pMovement.ToString());
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            _pos += Vector3.right * _spd * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.A))
        {
            _pos += Vector3.left * _spd * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.W))
        {
            _pos += Vector3.forward * _spd * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S))
        {
            _pos += Vector3.back * _spd * Time.deltaTime;
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
