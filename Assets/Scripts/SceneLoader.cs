using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
  public enum SceneIndex {
    StartMenu = 0,
    Game = 1,
    Win = 2,
    Lose = 3,
    Credits = 4
  };

  public static void LoadScene (SceneIndex index) {
    SceneManager.LoadScene((int) index);
  }

  public static void LoadGameScene () {
    LoadScene(SceneIndex.Game);
  }

  public static void LoadWinScene () {
    LoadScene(SceneIndex.Win);
  }

  public static void LoadLoseScene () {
    LoadScene(SceneIndex.Lose);
  }
  
  public static void LoadMenuScene () {
    LoadScene(SceneIndex.StartMenu);
  }

  public static void LoadCreditsScene () {
    LoadScene(SceneIndex.Credits);
  }
}
