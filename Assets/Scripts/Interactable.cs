using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Interactable : MonoBehaviour
{

    Outline outline;

    [Header("Interactable Info")]
    public string label;
    public bool interactDisabled; //Added when integrating ProgressCondition. Additional check for disabling interaction.

    [Header("Condition Check")]
    [SerializeField] private ProgressCondition condition;

    [Header("Progress Tracking")]
    public string progressFlagName;
    public bool setFlagTrue = true;

    [Header("Interaction Events")]
    public UnityEvent onInteract;
    public UnityEvent onConditionFail;

    void Start()
    {
        outline = GetComponent<Outline>();  
        DisableOutline();
    }

    public void Interact()
    {
        if (interactDisabled)
        {
            return;
        }
        
        if (condition != null && !condition.AllConditionsMet())
        {
            Debug.Log("Interaction blocked. Condition check performed.");
            onConditionFail.Invoke();

            //DisableOutline();
            //UI_Controller.instance.DisableInteractionText();

            return;
        }

        onInteract.Invoke();
        interactDisabled = true;
        DisableOutline();
        UI_Controller.instance.DisableInteractionText();

        if (!string.IsNullOrEmpty(progressFlagName))
        {
            ProgressTracker.instance.SetFlag(progressFlagName, setFlagTrue);
        }
    }

    public void DisableOutline()
    {
        outline.enabled = false;
    }

    public void EnableOutline()
    {
        outline.enabled = true;
    }

    public void DisableInteract()
    {
        interactDisabled = true;
    }

}
