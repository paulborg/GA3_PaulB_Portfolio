using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ProgressFlag
{
    public string flagName;
    public bool value;
}

public class ProgressTracker : MonoBehaviour
{
    public static ProgressTracker instance;

    [SerializeField] private List<ProgressFlag> flagList = new List<ProgressFlag>();

    private Dictionary<string, bool> flagDictionary = new Dictionary<string, bool>();

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Debug.LogWarning("Duplicated ProgressTracker Found and Destroyed!");
            Destroy(gameObject);
            return;
        }

        instance = this;
        Debug.Log("Progress Tracker Instance LIVE");

        foreach (var flag in flagList)
        {
            if (!flagDictionary.ContainsKey(flag.flagName))
            {
                flagDictionary.Add(flag.flagName, flag.value);
            }
                
        }
    }

    private IEnumerator Start()
    {
        yield return null;
        PrintAllFlags();
    }

    
    public void SetFlag(string flagName, bool value)
    {
        // Sync Dictionary Flags //
        if (flagDictionary.ContainsKey(flagName))
        { 
            flagDictionary[flagName] = value; 
        }
        else 
        {
            flagDictionary.Add(flagName, value);
        }
            
        // Sync List Flags //
        var existing = flagList.Find(f => f.flagName == flagName);
        if (existing != null)
        {
            existing.value = value;
        }         
        else
        {
            flagList.Add(new ProgressFlag { flagName = flagName, value = value });
        }
    }

    public bool GetFlag(string flagName)
    {
        if (flagDictionary.TryGetValue(flagName, out bool value))
        {
            return value;
        }
        return false;
    }

    // Helper Method for flag check from ProgressCondition.cs //
    public bool HasFlag(string flagName)
    {
        return flagDictionary.ContainsKey(flagName);
    }

    // Helper Method for setting flags from Events //

    public void SetFlagFromEvent(string flagName)
    {
        SetFlag(flagName, true);
    }

    // DEBUG Method for printing all flags //
    public void PrintAllFlags()
    {
        foreach (var kvp in flagDictionary)
        {
            Debug.Log($"{kvp.Key}: {kvp.Value}");
        }
            
    }

    // DEBUG GUI for displaying all flags and their values //
    private void OnGUI()
    {
        GUILayout.BeginArea(new Rect(10, 10, 300, 500), GUI.skin.box);
        GUILayout.Label("<b>Progress flagList</b>");
        foreach (var kvp in flagDictionary)
        {
            GUILayout.Label($"{kvp.Key}: {kvp.Value}");
        }
        GUILayout.EndArea();
    }
}

//public bool talkedToReceptionist;
//public bool waitedForGreenLight;
//public bool enteredRestrictedRoom;
//public bool followedInstructions;