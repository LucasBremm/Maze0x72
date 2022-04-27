using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
  public enum SceneIndex {
    StartMenu = 0,
    Game = 1,
    Restart = 2
  };

  public static void LoadScene (SceneIndex index) {
    SceneManager.LoadScene((int) index);
  }

  public static void LoadGameScene () {
    LoadScene(SceneIndex.Game);
  }

  public static void LoadRestartScene () {
    LoadScene(SceneIndex.Restart);
  }
  
  public static void LoadMenuScene () {
    LoadScene(SceneIndex.StartMenu);
  }
}
