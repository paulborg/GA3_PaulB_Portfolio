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
   

    private void OnTriggerEnter(Collider other)
    {
        if (!string.IsNullOrEmpty(tagFilter) && !other.gameObject.CompareTag(tagFilter) && !triggerDisabled)
        {
            return;
        }

        else
        {
            this.GetComponent<BoxCollider>().enabled = false;
        }

        if (condition != null && !condition.ConditionMet())
        {
            Debug.Log($"Trigger blocked. Condition check performed.'{condition.flagName}'");
            return;
        }

        onTriggerEnter.Invoke();
        triggerDisabled = true;
    }


    #region //Original OnTriggerEnter
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


    void OnTriggerExit(Collider other)
    {
        if (!string.IsNullOrEmpty(tagFilter) && !other.gameObject.CompareTag(tagFilter)) return;
        onTriggerExit.Invoke();
    }
}

