using UnityEditor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CustomEditor(typeof(InteractManager))]
public class InteractEditor : Editor
{
    InteractManager _iManager;

    /// <summary>
    /// universal Triggers
    /// </summary>
    SerializedProperty isTriggeredProp;
  
    /// <summary>
    /// Area Trigger
    /// </summary>
    SerializedProperty areaWidthProp;
    SerializedProperty areaHeightProp;
    SerializedProperty areaDepthProp;
    
    /// <summary>
    /// Count Trigger
    /// </summary>
    SerializedProperty amountProp;

    void OnEnable()
    {
        _iManager = (InteractManager)target;
    }

    public override void OnInspectorGUI()
    {
        _iManager.tType = (InteractManager.TriggerType)EditorGUILayout.EnumPopup("Trigger Type", _iManager.tType);
        
        switch (_iManager.tType)
        {
            case InteractManager.TriggerType.Interaction:
                {
                    break;
                }

            case InteractManager.TriggerType.Count:
                {
                    isTriggeredProp = serializedObject.FindProperty("isTriggered");
                    amountProp = serializedObject.FindProperty("amount");

                    EditorGUILayout.PropertyField(amountProp, new GUIContent("Trigger Amount"));
                    EditorGUILayout.PropertyField(isTriggeredProp, new GUIContent("Event Triggered"));

                    _iManager.amount = amountProp.intValue;
                    _iManager.isTriggered = isTriggeredProp.boolValue;

                    break;
                }

            case InteractManager.TriggerType.Area:
                {
                    isTriggeredProp = serializedObject.FindProperty("isTriggered");
                    areaWidthProp = serializedObject.FindProperty("areaWidth");
                    areaHeightProp = serializedObject.FindProperty("areaHeight");
                    areaDepthProp = serializedObject.FindProperty("areaDepth");

                    EditorGUILayout.PropertyField(areaWidthProp, new GUIContent("Trigger Width"));
                    EditorGUILayout.PropertyField(areaHeightProp, new GUIContent("Trigger Height"));
                    EditorGUILayout.PropertyField(areaDepthProp, new GUIContent("Trigger Depth"));
                    EditorGUILayout.PropertyField(isTriggeredProp, new GUIContent("Event Triggered"));


                    _iManager.areaWidth = areaWidthProp.floatValue;
                    _iManager.areaHeight = areaHeightProp.floatValue;
                    _iManager.areaDepth = areaDepthProp.floatValue;
                    _iManager.isTriggered = isTriggeredProp.boolValue;

                    break;
                }
        }
    }
}