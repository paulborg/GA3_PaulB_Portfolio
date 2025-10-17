using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;


public class LightTimer : MonoBehaviour
{
    
    [Header("Timer Settings")]
    public float remainingTime = 5f;
    public bool isTimerActive;
    private bool hasStarted;
    [SerializeField] private string startWhenFlagTrue = "TalkedToReceptionist";

    [Header("Light References")]
    public GameObject lightMesh;
    public Light lightToChange;
    public Material redMaterial;
    public Material greenMaterial;

    [Header("Progress Tracker")]
    public string progressFlagName = "HallwaySignalGreen";

    void Start()
    {
        isTimerActive = false;
        hasStarted = false;
        lightMesh.GetComponent<Renderer>().material = redMaterial;
        lightToChange.color = Color.red;
    }

    void Update()
    {
        if (!hasStarted && ProgressTracker.instance.GetFlag(startWhenFlagTrue))
        {
            StartTimer();
            hasStarted = true;
            Debug.Log("TalkedToReceptionist flag detected - Timer Started");
        }
        
        if (isTimerActive && remainingTime > 0f)
        {
            remainingTime -= Time.deltaTime;
        }
        else if (remainingTime < 0f)
        {
            remainingTime = 0f;
            isTimerActive = false;
            Debug.Log("Timer finished - signal green!");
            SignalGreen();
        }
    }

    public void StartTimer()
    {
        isTimerActive = true;
    }

    void SignalGreen()
    {
        lightMesh.GetComponent<Renderer>().material = greenMaterial;
        lightToChange.color = Color.green;
        ProgressTracker.instance.SetFlag(progressFlagName, true);
    }
}
