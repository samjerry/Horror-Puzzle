using UnityEditor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CustomEditor(typeof(EventManager))]
public class EventManagerEditor : Editor
{
    EventManager _eManager;

    /// <summary>
    /// universal events
    /// </summary>
    SerializedProperty isTriggeredProp;
  
    /// <summary>
    /// Move Event
    /// </summary>
    SerializedProperty targetPosProp;
    SerializedProperty moveSpdProp;
    
    /// <summary>
    /// Audio Event
    /// </summary>
    SerializedProperty audioProp;

    void OnEnable()
    {
        _eManager = (EventManager)target;
    }

    public override void OnInspectorGUI()
    {
        _eManager.eType = (EventManager.EventType)EditorGUILayout.EnumPopup("Event", _eManager.eType);
        switch (_eManager.eType)
        {
            case EventManager.EventType.Light:
                {
                    isTriggeredProp = serializedObject.FindProperty("isTriggered");

                    EditorGUILayout.PropertyField(isTriggeredProp, new GUIContent("Event Triggered"));
                    //_eManager.isTriggered = 
                    break;
                }
            case EventManager.EventType.Audio:
                {
                    isTriggeredProp = serializedObject.FindProperty("isTriggered");
                    audioProp = serializedObject.FindProperty("audio");

                    EditorGUILayout.PropertyField(isTriggeredProp, new GUIContent("Event Triggered"));
                    EditorGUILayout.PropertyField(audioProp, new GUIContent("Audio File"));
                    //_eManager.audio =
                    break;
                }
            case EventManager.EventType.Move:
                {
                    isTriggeredProp = serializedObject.FindProperty("isTriggered");
                    targetPosProp = serializedObject.FindProperty("targetPos");
                    moveSpdProp = serializedObject.FindProperty("moveSpd");

                    EditorGUILayout.PropertyField(isTriggeredProp, new GUIContent("Event Triggered"));
                    EditorGUILayout.PropertyField(targetPosProp, new GUIContent("Target Position"));
                    EditorGUILayout.PropertyField(moveSpdProp, new GUIContent("Movement Speed"));
                    //_eManager.targetPos = 
                    break;
                }
        }
    }
}