using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
  [SerializeField] Dialogue dialogue;

  public void TriggerDialogue()
  {
    FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
  }

  public void CloseDialog () {
    FindObjectOfType<DialogueManager>().CloseDialog();
  }
}
