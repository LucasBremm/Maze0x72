using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyBehaviour : MonoBehaviour
{
  void OnTriggerEnter2D(Collider2D other) {
    if (other.tag == "Player") {
      GameManager.instance.GotKey();
      gameObject.SetActive(false);
    }
  }
}
