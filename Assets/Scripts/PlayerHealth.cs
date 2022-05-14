using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] int health = 3;
    
    BlinkBehaviour blinkBehaviour;
    BoxCollider2D boxCollider;
    PlayerController controller;
    SpriteRenderer spriteRenderer;

    [SerializeField] Image[] hearts;

    void Start()
    {
      blinkBehaviour = GetComponent<BlinkBehaviour>();
      boxCollider = GetComponent<BoxCollider2D>();
      controller = GetComponent<PlayerController>();
      spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update() {
      for (int i = 0; i < hearts.Length; i++)
      {
        if (i >= health) {
          hearts[i].enabled = false;
        } else {
          hearts[i].enabled = true;
        }
      }  
    }

    public void processHit () {
      blinkBehaviour.Blink(0.125f);
      health -= 1;

      boxCollider.enabled = false;
      controller.enabled = false;

      if (health <= 0) {
        spriteRenderer.sortingOrder = -1; // Para que os inimigos "passem por cima"
        StartCoroutine(dieAnimation());
        return;
      }

      StartCoroutine(enableColliderAndController());
    }

    IEnumerator enableColliderAndController () {
      yield return new WaitForSeconds(0.25f);

      controller.enabled = true;

      yield return new WaitForSeconds(0.25f);

      boxCollider.enabled = true;
    }

    IEnumerator dieAnimation () {
      yield return new WaitForSeconds(1f);

      transform.Rotate(0, 0, 90);

      yield return new WaitForSeconds(1f);
      
      SceneLoader.LoadLoseScene();
      
      this.enabled = false;
    }
}
