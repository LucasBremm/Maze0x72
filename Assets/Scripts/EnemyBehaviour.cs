using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
  [SerializeField] Transform[] patrolPoints;
  [SerializeField] float speed = 5f;
  
  BlinkBehaviour blinkBehaviour;
  Rigidbody2D rbody;
  BoxCollider2D boxCollider;
  SpriteRenderer spriteRenderer;
  Vector2 moveTo;

  int pointsSize;
  int currentPointIndex = 0;

  bool isMovingForward = true;

  bool canMove = true;

  bool calledChangeIndex = false;

  void Start()
  {
    rbody = GetComponent<Rigidbody2D>();
    boxCollider = GetComponent<BoxCollider2D>();
    spriteRenderer = GetComponent<SpriteRenderer>();

    blinkBehaviour = GetComponent<BlinkBehaviour>();

    pointsSize = patrolPoints.Length;

    transform.position = patrolPoints[currentPointIndex].position;
    if (pointsSize > 1) {
      currentPointIndex++;
    }
  }

  void verifyFlip () {
    float actualX = transform.position.x;
    float patrolX = patrolPoints[currentPointIndex].position.x;

    if (patrolX > actualX) {
      spriteRenderer.flipX = true;
    } else if (patrolX < actualX) {
      spriteRenderer.flipX = false;
    }
  }

  void verifyIndex () {
    if (transform.position == patrolPoints[currentPointIndex].position && !calledChangeIndex) {
      calledChangeIndex = true;
      StartCoroutine(changePointIndex());
    }
  }

  IEnumerator changePointIndex () {
    yield return new WaitForSeconds(0.5f); 
    changeIndex();
  }

  void Update()
  {
    verifyFlip();
    verifyIndex();
  }

  void calculateAndMove () {
    if (canMove) {
      Vector2 moveAmount = Vector2.MoveTowards(rbody.position, patrolPoints[currentPointIndex].position, speed * Time.fixedDeltaTime);
      rbody.MovePosition(moveAmount);  
    }
  }
  
  void FixedUpdate() {
    calculateAndMove();   
  }

  void changeIndex () {
    if (isMovingForward && currentPointIndex + 1 < pointsSize) {
      currentPointIndex++;
    } else if (isMovingForward && currentPointIndex + 1 >= pointsSize) {
      currentPointIndex--;
      isMovingForward = false;
    } else if (!isMovingForward && currentPointIndex - 1 >= 0) {
      currentPointIndex--;
    } else if (!isMovingForward && currentPointIndex - 1 < 0) {
      currentPointIndex++;
      isMovingForward = true;
    }
    calledChangeIndex = false;
  }

  private void OnTriggerEnter2D(Collider2D other) {
    if (other.tag == "Player") {
      other.GetComponent<PlayerHealth>().processHit();
    }
  }

  public void GetHit () {
    canMove = false;
    blinkBehaviour.Blink(0.125f);
  
    StartCoroutine(Die());
  }

  IEnumerator Die () {
    boxCollider.enabled = false;

    yield return new WaitForSeconds(0.5f);

    transform.Rotate(0, 0, 90);

    this.enabled = false;
  }

}
