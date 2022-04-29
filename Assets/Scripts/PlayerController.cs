using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
  Rigidbody2D rbody;
  SpriteRenderer spriteRenderer;

  [SerializeField] float speed = 5f;
  Vector2 moveDelta;
  // Start is called before the first frame update
  void Start()
  {
      rbody = GetComponent<Rigidbody2D>();
      spriteRenderer = GetComponent<SpriteRenderer>();
  }

  // Update is called once per frame
  void Update()
  {
    moveDelta.x = Input.GetAxisRaw("Horizontal");
    moveDelta.y = Input.GetAxisRaw("Vertical");

    if (moveDelta.x < 0) {
      // transform.localScale = new Vector3(-1, 1, 1);
      spriteRenderer.flipX = true;
    } else if (moveDelta.x > 0) {
      spriteRenderer.flipX = false;
      // transform.localScale = Vector3.one;
    }
  }

  void FixedUpdate() {
    rbody.MovePosition(rbody.position + (moveDelta.normalized * speed * Time.fixedDeltaTime));
    // rbody.velocity = moveDelta.normalized * speed;
  }
}
