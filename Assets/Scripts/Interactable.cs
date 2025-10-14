using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Interactable : MonoBehaviour
{

    Outline outline;
    public string label;
    //public bool interactUsed;

    [Header("Progress Tracking")]
    public string progressFlagName;
    public bool setFlagTrue = true;

    public UnityEvent onInteract;

    [Header("Condition Check")]
    [SerializeField] private ProgressCondition condition;

    void Start()
    {
        outline = GetComponent<Outline>();  
        DisableOutline();
    }

    public void Interact()
    {
        if (condition != null && !condition.ConditionMet())
        {
            Debug.Log($"Interaction blocked. Condition check performed.'{condition.flagName}'");
            return;
        }

        onInteract.Invoke();

        if (!string.IsNullOrEmpty(progressFlagName))
        {
            ProgressTracker.instance.SetFlag(progressFlagName, setFlagTrue);
        }

        //interactUsed = true;
    }

    public void DisableOutline()
    {
        outline.enabled = false;
    }

    public void EnableOutline()
    {
        outline.enabled = true;
    }


}
