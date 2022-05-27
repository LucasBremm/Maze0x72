using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SignBehaviour : MonoBehaviour
{
  DialogueTrigger dialogueTrigger;

  void Start()
  {
    dialogueTrigger = GetComponent<DialogueTrigger>();
  }

  private void OnTriggerEnter2D(Collider2D other) {
    dialogueTrigger.TriggerDialogue();
  }

  private void OnTriggerExit2D(Collider2D other) {
    dialogueTrigger.CloseDialog();
  }
}
