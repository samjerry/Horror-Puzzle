using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum MovementTypes { walk, run, sprint, crouch};
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] KeyCode _forwardKey;
    [SerializeField] KeyCode _backwardKey;
    [SerializeField] KeyCode _leftKey;
    [SerializeField] KeyCode _rightKey;
    [SerializeField] KeyCode _crouchKey;
    [SerializeField] KeyCode _walkKey;
    [SerializeField] KeyCode _sprintKey;

    [SerializeField] MovementTypes _pMovement;
    

    [SerializeField] float _runSpd = 1f;
    [SerializeField] float _walkSpd = 0.5f;
    [SerializeField] float _crouchSpd = 0.25f;
    [SerializeField] float _sprintSpd = 1.5f;
    [SerializeField] float _spd;

    bool _isGrounded;

    void Start()
    {
        
        _pMovement = MovementTypes.run;

        SetSpeed();
    }

    void Update()
    {

        /// <summary>
        /// Keyboard Input.
        /// </summary>

        if (Input.GetKey(_sprintKey))
        {
            _pMovement = MovementTypes.sprint;
            SetSpeed();
        }
        if (Input.GetKey(_walkKey))
        {
            _pMovement = MovementTypes.walk;
            SetSpeed();
        }
        if (Input.GetKey(_crouchKey))
        {
            _pMovement = MovementTypes.crouch;
            SetSpeed();

            if (Input.GetKey(_sprintKey))
            {
                _spd = _crouchSpd * 1.5f;
            }
        }
        if (Input.GetKeyUp(_crouchKey) && !Input.GetKey(_sprintKey) && !Input.GetKey(_walkKey))
        {
            _pMovement = MovementTypes.run;
            SetSpeed();
        }
        if (Input.GetKeyUp(_walkKey) && !Input.GetKey(_crouchKey) && !Input.GetKey(_sprintKey))
        {
            _pMovement = MovementTypes.run;
            SetSpeed();
        }
        if (Input.GetKeyUp(_sprintKey) && !Input.GetKey(_crouchKey) && !Input.GetKey(_walkKey))
        {
            _pMovement = MovementTypes.run;
            SetSpeed();
        } 
        
        if (Input.GetKey(_rightKey))
        {
            transform.position += (Vector3.right * _spd * Time.deltaTime);
        }
        if (Input.GetKey(_leftKey))
        {
            transform.position += (Vector3.left * _spd * Time.deltaTime);
        }
        if (Input.GetKey(_forwardKey))
        {
            transform.position += (Vector3.forward * _spd * Time.deltaTime);
        }
        if (Input.GetKey(_backwardKey))
        {
            transform.position += (Vector3.back * _spd * Time.deltaTime);
        }

        transform.rotation = GameObject.Find("Main Camera").transform.rotation;

    }

    void SetSpeed()
    {
        switch (_pMovement.ToString())
        {
            case "run":
                _spd = _runSpd;
                break;
            case "sprint":
                _spd = _sprintSpd;
                break;
            case "crouch":
                _spd = _crouchSpd;
                break;
            case "walk":
                _spd = _walkSpd;
                break;

            default:
                break;
        }
    }

}
