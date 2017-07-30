using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyForSeconds : MonoBehaviour {

  public int seconds = 0;

  void Start () {
    Invoke("Destroy", seconds);
  }

  void Destroy () {
    Destroy(gameObject);
  }
}
