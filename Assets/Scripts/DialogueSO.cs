using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="NewDialogue", menuName = "DialogueSO")]
public class DialogueSO : ScriptableObject
{
    public string charName;
    public string[] dialogueLines;

    public DialogueChoice[] choices;

}

[System.Serializable]
public class DialogueChoice
{
    public int dialogueIndex; //To mark the line where choices will appear
    public string[] choices;  //Choice options available 
    public int[] nextDialogueIndexes; //To mark the line that follows a choice

    public string[] traitToUpdate;
    public float[] traitDelta;
}


