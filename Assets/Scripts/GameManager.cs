using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
  public static GameManager instance { get; private set; }
  
  public bool hasKey { get; private set; } = false;
  public static bool hasWon { get; private set; } = false;
  

  [SerializeField] Image UIKey;

  void Awake()
  {
    if (instance != null && instance != this) 
    { 
      Destroy(this);
      return;
    } 
   
    instance = this;
    // DontDestroyOnLoad(this); 
  }

  public void GotKey () {
    hasKey = true;
    UIKey.enabled = true;
  }

  public void PlayerWin () {
    hasWon = true;
  }
}
