using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Power : MonoBehaviour {

  public float maxPower = 400;
  public float currentPower = 200;
  public float powerBaseLoseRate = 5;
  public float powerLoadGain = 4;
  public int powerPrecentage = 100;

  void Start () {
    
  }

  void Update () {
    HandlePower();
  }

  void HandlePower () {

    if (currentPower != 0) {
      Consume();
    }
  }

  public void Consume (float extraLoseRate = 1) {
    float powerLose = Time.deltaTime * powerBaseLoseRate * extraLoseRate;
    float newCurrentPower = currentPower - powerLose;
    currentPower = newCurrentPower < 0 ? 0 : newCurrentPower;
    powerPrecentage = Mathf.RoundToInt((currentPower / maxPower) * 100);
  }

  public void Load () {
    float newCurrentPower = currentPower + powerLoadGain;

    currentPower = newCurrentPower > maxPower ? maxPower : newCurrentPower;
    powerPrecentage = Mathf.RoundToInt((currentPower / maxPower) * 100);
  }
}
