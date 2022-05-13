using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
  Rigidbody2D rbody;
  SpriteRenderer spriteRenderer;

  [SerializeField] float speed = 5f;
  Vector2 moveDelta;
  
  GameObject attack;
  Vector3 attackPosition = new Vector3(0.6f, 0.0f, 0.0f);
  Vector3 attackFlippedPosition = new Vector3(-0.6f, 0.0f, 0.0f);
  
  GameObject sword;
  Vector3 swordPosition = new Vector3(0.3f, 0.1f, 0.0f);
  Vector3 swordFlippedPosition = new Vector3(-0.3f, 0.1f, 0.0f);

  void Start()
  {
      rbody = GetComponent<Rigidbody2D>();
      spriteRenderer = GetComponent<SpriteRenderer>();
      attack = transform.GetChild(0).gameObject;
      sword = transform.GetChild(1).gameObject;
  }

  void Update()
  {
    calculateMove();
    verifyFlip();
  }

  void calculateMove () {
    moveDelta.x = Input.GetAxisRaw("Horizontal");
    moveDelta.y = Input.GetAxisRaw("Vertical");
  }

  void verifyFlip () {
    if (moveDelta.x < 0) {
      spriteRenderer.flipX = true;
      attack.transform.localPosition = attackFlippedPosition;
      sword.transform.localPosition = swordFlippedPosition;
      sword.GetComponent<Weapon>().setFlipped(true);
    } else if (moveDelta.x > 0) {
      spriteRenderer.flipX = false;
      attack.transform.localPosition = attackPosition;
      sword.transform.localPosition = swordPosition;
      sword.GetComponent<Weapon>().setFlipped(false);
    }
  }

  void FixedUpdate() {
    rbody.MovePosition(rbody.position + (moveDelta.normalized * speed * Time.fixedDeltaTime));
  }
}
