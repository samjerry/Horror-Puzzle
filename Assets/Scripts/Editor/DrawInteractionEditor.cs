using UnityEditor;
using UnityEngine;
using System.Collections.Generic;
using System;

[CustomEditor(typeof(GetEventReceivers))]
class DrawInteractionEditor : Editor
{
    Transform targetObject;
    GameObject[] _interactables;

    private void OnEnable()
    {
        targetObject = (target as GetEventReceivers).transform;
    }

    void OnSceneGUI()
    {
        Handles.color = Color.yellow;

        _interactables = (GameObject[])targetObject.GetComponent<GetEventReceivers>().eventReceivers.Clone();

        for (int i = 0; i < _interactables.Length; i++)
        {
            Handles.DrawLine(targetObject.position, _interactables[i].transform.position);
        }
    }
}