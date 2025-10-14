using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BasicTrigger : MonoBehaviour
{
    [SerializeField] string tagFilter;
    [SerializeField] UnityEvent onTriggerEnter;
    [SerializeField] UnityEvent onTriggerExit;
    //[SerializeField] bool triggerUsed;

    [Header("Condition Check")]
    [SerializeField] private ProgressCondition condition;

    private void OnTriggerEnter(Collider other)
    {
        if (!string.IsNullOrEmpty(tagFilter) && !other.gameObject.CompareTag(tagFilter))
        {
            return;
        }

        if (condition != null && !condition.ConditionMet())
        {
            Debug.Log($"Trigger blocked. Condition check performed.'{condition.flagName}'");
            return;
        }

        onTriggerEnter.Invoke();

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

