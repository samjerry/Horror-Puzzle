using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum MovementTypes { walk, run, sprint, crouch};
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private KeyCode _forwardKey;
    [SerializeField] private KeyCode _backwardKey;
    [SerializeField] private KeyCode _leftKey;
    [SerializeField] private KeyCode _rightKey;
    [SerializeField] private KeyCode _crouchKey;
    [SerializeField] private KeyCode _walkKey;
    [SerializeField] private KeyCode _sprintKey;

    [SerializeField] private MovementTypes _pMovement;

    [SerializeField] private CharacterController _controller;

    [SerializeField] private float _runSpd = 1f;
    [SerializeField] private float _walkSpd = 0.5f;
    [SerializeField] private float _crouchSpd = 0.25f;
    [SerializeField] private float _sprintSpd = 1.5f;
    [SerializeField] private float _spd;
    [SerializeField] private float _gravity;

    [SerializeField] private Transform _groundCheck;
    [SerializeField] private float _checkDistance = 0.4f;
    [SerializeField] private LayerMask groundMask;

    private bool _isGrounded;

    private Vector3 _velocity;

    private float _x;
    private float _z;

    void Start()
    {
        
        _pMovement = MovementTypes.run;

        SetSpeed();
    }

    void Update()
    {
        _isGrounded = Physics.CheckSphere(_groundCheck.position, _checkDistance, groundMask);

        if (_isGrounded && _velocity.y < 0)
        {
            _velocity.y = -2f;
        }

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

        _x = Input.GetAxis("Horizontal");
        _z = Input.GetAxis("Vertical");

        Vector3 _move = transform.right * _x + transform.forward * _z;

        _controller.Move(_move * _spd * Time.deltaTime);

        _velocity.y += _gravity * Time.deltaTime;

        _controller.Move(_velocity * Time.deltaTime);
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
