using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TraitsManager : MonoBehaviour
{
    public float openness = 0f;
    public float conscientiousness = 0f;
    public float extroversion = 0f;
    public float agreeableness = 0f;
    public float neuroticism = 0f;

    public TMP_Text opennessText;
    public TMP_Text conscientiousnessText;
    public TMP_Text extroversionText;
    public TMP_Text agreeablenessText;
    public TMP_Text neuroticismText;

    public void UpdateTraits(string trait, float delta)
    {
        switch (trait)
        {
            case "openness":
                openness = Mathf.Clamp(openness + delta, -1f, 1f);
                break;

            case "conscientiousness":
                conscientiousness = Mathf.Clamp(conscientiousness + delta, -1f, 1f);
                break;

            case "extroversion":
                extroversion = Mathf.Clamp(extroversion + delta, -1f, 1f);
                break;

            case "agreeableness":
                agreeableness = Mathf.Clamp(agreeableness + delta, -1f, 1f);
                break;

            case "neuroticism":
                neuroticism = Mathf.Clamp(neuroticism + delta, -1f, 1f);
                break;
        }

        RefreshTraitsUI();
    }

    public void RefreshTraitsUI()
    {
        opennessText.text = $"Openness: {openness:F1}";
        conscientiousnessText.text = $"Conscientiousness: {conscientiousness:F1}";
        extroversionText.text = $"Extroversion: {extroversion:F1}";
        agreeablenessText.text = $"Agreeableness: {agreeableness:F1}";
        neuroticismText.text = $"Neuroticism: {neuroticism:F1}";

    }
}

#region //UpdateTraits(With Normalized Clamp)
//public void UpdateTraits(string trait, float delta)
//{
//    switch (trait)
//    {
//        case "openness":
//            openness = Mathf.Clamp01(openness + delta);
//            break;

//        case "conscientiousness":
//            conscientiousness = Mathf.Clamp01(conscientiousness + delta);
//            break;

//        case "extroversion":
//            extroversion = Mathf.Clamp01(extroversion + delta);
//            break;

//        case "agreeableness":
//            agreeableness = Mathf.Clamp01(agreeableness + delta);
//            break;

//        case "neuroticism":
//            neuroticism = Mathf.Clamp01(neuroticism + delta);
//            break;
//    }
#endregion