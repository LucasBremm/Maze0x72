using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyBehaviour : MonoBehaviour
{
  Transform[] locations;

  void Start() {
    locations = GetComponentsInChildren<Transform>();

    int index = Random.Range(0, locations.Length);

    transform.position = locations[index].position;  
  }

  void OnTriggerEnter2D(Collider2D other) {
    if (other.tag == "Player") {
      GameManager.instance.GotKey();
      gameObject.SetActive(false);
    }
  }
}
