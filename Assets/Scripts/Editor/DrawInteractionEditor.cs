using UnityEditor;
using UnityEngine;
using System.Collections.Generic;
using System;

[CustomEditor(typeof(GetEventReceivers))]
class DrawInteractionEditor : Editor
{
    Transform _targetObject;
    GameObject[] _interactables;

    private void OnEnable()
    {
        _targetObject = (target as GetEventReceivers).transform;
    }

    void OnSceneGUI()
    {
        Handles.color = Color.yellow;

        _interactables = (GameObject[])_targetObject.GetComponent<GetEventReceivers>().eventReceivers.Clone();

        for (int i = 0; i < _interactables.Length; i++)
        {
            Handles.DrawLine(_targetObject.position, _interactables[i].transform.position);
        }
    }
}