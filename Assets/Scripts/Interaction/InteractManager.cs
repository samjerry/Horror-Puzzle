using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractManager : MonoBehaviour
{
    public enum TriggerType
    {
        Interaction,
        Area,
        Count
    }

    public TriggerType tType;

    /// <summary>
    /// Universal Trigger
    /// <summary>
    public bool isTriggered;

    /// <summary>
    /// Interaction Trigger
    /// </summary>
    private InteractionCheck _interactCheck;

    /// <summary>
    /// Count Trigger
    /// </summary>
    public int amount;

    /// <summary>
    /// Area Trigger
    /// </summary>
    public float areaWidth;
    public float areaHeight;
    public float areaDepth;


    // Start is called before the first frame update
    void Start()
    {
        _interactCheck = GetComponent<InteractionCheck>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && _interactCheck.target != null)
        {
            _interactCheck.target.GetComponent<TriggerEvent>().InvokeEvent();
        }
    }
}