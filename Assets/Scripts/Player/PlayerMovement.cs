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

    void Start()
    {
        _pMovement = MovementTypes.walk;
    }

    void Update()
    {
        if (Input.GetAxis("Vertical") > 0)
        {
            var a = transform.TransformDirection(0, 0, 50); //up
            controller.SimpleMove(a * speed);
        }
        if (Input.GetAxis("Vertical") < 0)
        {
            var b = transform.TransformDirection(0, 50, 0); // down
            controller.SimpleMove(b * speed);
        }
        if (Input.GetAxis("Horizontal") > 0)
        {
            var c = transform.TransformDirection(50, 0, 0); //right
            controller.SimpleMove(c * speed);
        }
        if (Input.GetAxis("Horizontal") < 0)
        {
            var d = transform.TransformDirection(-50, 0, 0); // left
            controller.SimpleMove(d * speed);
        }
    }
}
