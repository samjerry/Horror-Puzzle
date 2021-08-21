using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event : MonoBehaviour
{
    [SerializeField] private Vector3 _newPos;

    [SerializeField] private Color _newColor;

    [SerializeField] private float _rotAmount;
    [SerializeField] private float _moveSpd;

    public void MoveObjectEvent() => transform.position = Vector3.MoveTowards(transform.position, _newPos, _moveSpd * Time.deltaTime);

    public void ChangeMatEvent() => GetComponent<Material>().SetColor("Albedo", _newColor);

    public void RotateEvent()
    {

    }
    
}
