using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{   
    public DialogueSO dialogueData;

    private int dialogueIndex;
    private UI_Controller uiController;
    [SerializeField]public bool isDialogueActive;

    public TraitsManager traitsManager;
    PlayerController playerController;

   

    private void Start()
    {
        uiController = UI_Controller.instance;
        playerController = FindObjectOfType<PlayerController>();
    }

    private void Awake()
    {
        isDialogueActive = false;
    }

    public void StartDialogue()
    {
        //Debug.Log($"Starting dialogue for {this.gameObject.name} using DialogueSO: {dialogue.name}");
        isDialogueActive = true;
        dialogueIndex = 0;

        uiController.SetDialogueText(dialogueData.dialogueLines[dialogueIndex]);
        uiController.ShowDialogueUI(true);
        uiController.SetCharInfo(dialogueData.charName);

        playerController.canMove = false;
        playerController.UnlockCursor();

        NextLine();

    }

    public void NextLine()
    {
        Debug.Log($"NextLine() called on: {gameObject.name}");
        uiController.ClearChoices();

        if (dialogueIndex >= dialogueData.dialogueLines.Length)
        {
            uiController.ClearChoices();
            EndDialogue();
            return;
        }

        uiController.SetDialogueText(dialogueData.dialogueLines[dialogueIndex]);

        foreach(DialogueChoice dialogueChoice in dialogueData.choices)
        {
            if(dialogueChoice.dialogueIndex == dialogueIndex)
            {
                DisplayChoices(dialogueChoice);
                return;
            }
        }
        dialogueIndex++; 
    }

    //if (++dialogueIndex > dialogueData.dialogueLines.Length)
    //{
    //    EndDialogue();
    //}

    void DisplayChoices(DialogueChoice choices)
    {
        for (int i = 0; i < choices.choices.Length; i++)
        {
            int nextIndex = choices.nextDialogueIndexes[i];
            string trait = "";
            float delta = 0f;

            if (choices.traitToUpdate != null && i < choices.traitToUpdate.Length)
            {
                trait = choices.traitToUpdate[i];
            }

            if (choices.traitDelta != null && i < choices.traitDelta.Length)
            {
                delta = choices.traitDelta[i];
            }

            string traitToUpdate = trait;
            float traitDelta = delta;

            uiController.CreateChoiceButton(choices.choices[i], () =>
            {
                if (!string.IsNullOrEmpty(traitToUpdate))
                {
                    traitsManager.UpdateTraits(traitToUpdate, traitDelta);
                }

                ChooseOption(nextIndex);
            });
        }   
    }

    void ChooseOption(int nextIndex)
    {
        dialogueIndex = nextIndex;
        uiController.ClearChoices();
        NextLine();
    }


   public void EndDialogue()
    {
        isDialogueActive = false;
        uiController.SetDialogueText("");
        uiController.ShowDialogueUI(false);
        uiController.ClearChoices();
        playerController.canMove = true;
        playerController.LockCursor();
    }

}


