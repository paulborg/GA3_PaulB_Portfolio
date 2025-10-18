using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ConditionCheck
{
    public string flagName;
    public bool requiredValue = true;
}

public class ProgressCondition : MonoBehaviour
{
    [SerializeField] private ConditionCheck[] conditions;
    [SerializeField] private bool useOrLogic = false;

    public bool AllConditionsMet()
    {
        if (conditions == null || conditions.Length == 0)
        {
            return true;
        }

        if (useOrLogic)
        {
            foreach (var condition in conditions)
            {
                if (ProgressTracker.instance.HasFlag(condition.flagName) && ProgressTracker.instance.GetFlag(condition.flagName) == condition.requiredValue)
                {
                    return true;
                }
            }
            return false;
        }

        else
        {
            foreach (var condition in conditions)
            {
                if (!ProgressTracker.instance.HasFlag(condition.flagName))
                {
                    return false;
                }

                if (ProgressTracker.instance.GetFlag(condition.flagName) != condition.requiredValue)
                {
                    return false;
                }

            }
            return true;
        }
    }
}



#region // First iteration of ConditionMet() method, before expanding to allow multiple condition checks //
//public bool ConditionMet()
//{
//    if (ProgressTracker.instance == null)
//    {
//        Debug.Log("No ProgressTracker Instance Found!");
//        return false;
//    }
//    return ProgressTracker.instance.GetFlag(flagName) == requiredValue;
//}
//    }
#endregion 