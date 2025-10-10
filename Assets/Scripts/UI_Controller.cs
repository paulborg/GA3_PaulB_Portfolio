using System.Collections.Generic;
using System.Collections;
using UnityEngine.UI;
using UnityEngine;
using TMPro;


public class UI_Controller : MonoBehaviour
{
    [Header("Interaction UI")]
    [SerializeField] TMP_Text interactText;

    [Header("Dialogue UI")]
    public GameObject dialoguePanel;
    public TMP_Text nameText;
    public TMP_Text dialogueText;
    public Transform buttonsPanel;
    public GameObject buttonPrefab;
    

    public static UI_Controller instance;

    private void Awake()
    {
        instance = this;
    }


    #region Interaction UI Methods 
    public void EnableInteractionText(string text)
    {
        interactText.text = text + "[E]";
        interactText.gameObject.SetActive(true);
    }

    public void DisableInteractionText()
    {
        interactText.gameObject.SetActive(false);
    }
    #endregion

    #region DialogueUI Methods
    public void ShowDialogueUI(bool show)
    {
        dialoguePanel.SetActive(show);
    }

    public void SetCharInfo(string charName)
    {
        nameText.text = charName;
    }

    public void SetDialogueText(string text)
    {
        dialogueText.text = text;
    }

    public void ClearChoices()
    {
        foreach (Transform child in buttonsPanel) Destroy(child.gameObject);
    }

    public GameObject CreateChoiceButton(string choiceText, UnityEngine.Events.UnityAction onClick)
    {
        GameObject choiceButton = Instantiate(buttonPrefab, buttonsPanel);
        choiceButton.GetComponentInChildren<TMP_Text>().text = choiceText;
        choiceButton.GetComponent<Button>().onClick.AddListener(onClick);
        return choiceButton;
    }
    #endregion

}
