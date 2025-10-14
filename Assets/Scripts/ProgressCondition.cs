using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ProgressCondition
{
     public string flagName;
     public bool requiredValue = true;

     public bool ConditionMet()
     {
            if (ProgressTracker.instance == null)
            {
                Debug.Log("No ProgressTracker Instance Found!");
                return false;
            }
            return ProgressTracker.instance.GetFlag(flagName) == requiredValue;
        }
    }
