using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BasicTrigger : MonoBehaviour
{
    [Header("Trigger Info")]
    [SerializeField] string tagFilter;
    [SerializeField] bool triggerDisabled;

    [Header("Condition Check")]
    [SerializeField] private ProgressCondition condition;

    [Header("Trigger Events")]

    [SerializeField] UnityEvent onTriggerEnter;
    [SerializeField] UnityEvent onTriggerExit;
    [SerializeField] UnityEvent onConditionFail;
   

    private void OnTriggerEnter(Collider other)
    {
        if (!string.IsNullOrEmpty(tagFilter) && !other.gameObject.CompareTag(tagFilter)) // && !triggerDisabled
        {
            return;
        }

        //else
        //{
        //    this.GetComponent<BoxCollider>().enabled = false;
        //}

        if (condition != null && !condition.AllConditionsMet())
        {
            onConditionFail.Invoke();
            Debug.Log("Trigger blocked. Condition check performed.");
        }

        else
        {
            onTriggerEnter.Invoke();
        }

        // triggerDisabled = true;
    }

    void OnTriggerExit(Collider other)
    {
        if (!string.IsNullOrEmpty(tagFilter) && !other.gameObject.CompareTag(tagFilter))
        {
            return;
        }
        onTriggerExit.Invoke();
    }
}

#region // First iteration of BasicTrigger.cs OnTriggerEnter method //
//void OnTriggerEnter(Collider other)
//{
//    if (!string.IsNullOrEmpty(tagFilter) && !other.gameObject.CompareTag(tagFilter) && !triggerUsed)  
//        return;

//    else
//    {
//        this.GetComponent<BoxCollider>().enabled = false;
//    }
//    onTriggerEnter.Invoke();
//    triggerUsed = true;

//}

#endregion

