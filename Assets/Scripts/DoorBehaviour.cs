using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorBehaviour : MonoBehaviour
{
  SpriteRenderer spriteRenderer;
  BoxCollider2D boxCollider;

  [SerializeField] Sprite openSprite;

  void Start() {
    spriteRenderer = GetComponent<SpriteRenderer>();  
    boxCollider = GetComponent<BoxCollider2D>();  
  }

  private void OnCollisionEnter2D(Collision2D other) {
    if (other.gameObject.tag == "Player" && GameManager.instance.hasKey) {
      spriteRenderer.sprite = openSprite;
      GameManager.instance.PlayerWin();
      Physics2D.IgnoreCollision(boxCollider, other.collider, true);
      Invoke("callRestartScene", 0.5f);
    }
  }

  private void callRestartScene () {
      SceneLoader.LoadWinScene();
  }
}
