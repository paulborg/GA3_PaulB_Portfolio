using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Interactable : MonoBehaviour
{

    Outline outline;
    public string label;
    public bool interactUsed;

    public UnityEvent onInteract;

    void Start()
    {
        outline = GetComponent<Outline>();  
        DisableOutline();
    }

    public void Interact()
    {
        onInteract.Invoke();
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
