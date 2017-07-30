using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathDetector : MonoBehaviour {
  void OnTriggerEnter2D(Collider2D other) {
    if (other.tag == "Player") {
      other.GetComponent<Player>().Respawn();
    }
  }
}
