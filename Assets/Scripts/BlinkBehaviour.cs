using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlinkBehaviour : MonoBehaviour
{
  [SerializeField] Material blinkMaterial;
  
  private SpriteRenderer spriteRenderer;
  private Material originalMaterial;

  private Coroutine blinkRoutine;

  void Start()
  {
    spriteRenderer = GetComponent<SpriteRenderer>();

    originalMaterial = spriteRenderer.material;
  }

  public void Blink(float duration) {
    if (blinkRoutine != null) {
      StopCoroutine(blinkRoutine);
    }

    blinkRoutine = StartCoroutine(BlinkRoutine(duration));
  }

  private IEnumerator BlinkRoutine(float duration) {
    spriteRenderer.material = blinkMaterial;

    yield return new WaitForSeconds(duration);

    spriteRenderer.material = originalMaterial;

    blinkRoutine = null;
  }
}
