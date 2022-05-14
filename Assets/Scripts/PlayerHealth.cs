using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] int health = 3;
    
    BlinkBehaviour blinkBehaviour;
    PlayerController controller;
    Weapon weaponController;
    SpriteRenderer spriteRenderer;

    [SerializeField] Image[] hearts;

    void Start()
    {
      blinkBehaviour = GetComponent<BlinkBehaviour>();
      controller = GetComponent<PlayerController>();
      weaponController = GetComponentInChildren<Weapon>();
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

      controller.enabled = false;
      weaponController.enabled = false;

      if (health <= 0) {
        spriteRenderer.sortingOrder = -1; // Para que os inimigos "passem por cima"
        weaponController.GetComponentInChildren<SpriteRenderer>().sortingOrder = -1; // Para que os inimigos "passem por cima"
        StartCoroutine(dieAnimation());
        return;
      }

      StartCoroutine(enableColliderAndController());
    }

    IEnumerator enableColliderAndController () {
      yield return new WaitForSeconds(0.25f);

      controller.enabled = true;
      weaponController.enabled = true;
    }

    IEnumerator dieAnimation () {
      yield return new WaitForSeconds(1f);

      transform.Rotate(0, 0, 90);

      yield return new WaitForSeconds(1f);
      
      SceneLoader.LoadLoseScene();
      
      this.enabled = false;
    }
}
