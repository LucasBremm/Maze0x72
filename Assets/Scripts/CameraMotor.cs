using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMotor : MonoBehaviour
{
  [SerializeField] Transform lookAt;

  [SerializeField] float topBoundY = 10;
  [SerializeField] float bottomBoundY = -10;
  
  [SerializeField] float topBoundX = 5;
  [SerializeField] float bottomBoundX = -5;
  
  [SerializeField] float boundX = 0.15f;
  [SerializeField] float boundY = 0.05f;
   
  float getDelta (float lookAtPos, float transformPos, float bound) {
    float delta = lookAtPos - transformPos;

    if ((delta < bound) && (delta > -1 * bound)) {
        return 0;
    }
    
    if (transformPos < lookAtPos) {
        return delta - bound;
    } else {
        return delta + bound;
    }
  }

  void LateUpdate() {
    Vector3 delta = Vector3.zero;
    delta.x = getDelta(lookAt.position.x, transform.position.x, boundX);
    delta.y = getDelta(lookAt.position.y, transform.position.y, boundY);

    float newX = Mathf.Clamp(transform.position.x + delta.x, bottomBoundX, topBoundX);
    float newY = Mathf.Clamp(transform.position.y + delta.y, bottomBoundY, topBoundY);

    transform.position = new Vector3(newX, newY, -10);
  }
}
