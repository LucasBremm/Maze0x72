using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
  [SerializeField] Transform[] patrolPoints;
  [SerializeField] float speed = 5f;
  
  Rigidbody2D rbody;
  Vector2 moveTo;

  int pointsSize;
  int currentPointIndex = 0;

  bool isMovingForward = true;



  bool calledChangeIndex = false;

  void Start()
  {
    rbody = GetComponent<Rigidbody2D>();

    pointsSize = patrolPoints.Length;

    transform.position = patrolPoints[currentPointIndex].position;
    if (pointsSize > 1) {
      currentPointIndex++;
    }
  }

  void Update()
  {
    if (transform.position == patrolPoints[currentPointIndex].position && !calledChangeIndex) {
      calledChangeIndex = true;
      StartCoroutine(changePointIndex());
    }
  }

  void FixedUpdate() {
    Vector2 moveAmount = Vector2.MoveTowards(rbody.position, patrolPoints[currentPointIndex].position, speed * Time.fixedDeltaTime);
    rbody.MovePosition(moveAmount);  
  }

  IEnumerator changePointIndex () {
    yield return new WaitForSeconds(0.5f); 
    changeIndex();
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

  private void OnCollisionEnter2D(Collision2D other) {
    if (other.gameObject.tag == "Player") {
      SceneLoader.LoadLoseScene();
    }
  }
}
