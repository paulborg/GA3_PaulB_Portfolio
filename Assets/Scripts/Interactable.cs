using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Interactable : MonoBehaviour
{

    Outline outline;
    public string label;
    public bool interactUsed;

    [Header("Progress Tracking")]
    public string progressFlagName;
    public bool setFlagTrue = true;

    public UnityEvent onInteract;

    void Start()
    {
        outline = GetComponent<Outline>();  
        DisableOutline();
    }

    public void Interact()
    {
        onInteract.Invoke();

        if (!string.IsNullOrEmpty(progressFlagName))
        {
            ProgressTracker.instance.SetFlag(progressFlagName, setFlagTrue);
        }

        interactUsed = true;
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
