using UnityEngine;

public class GroundCheck : MonoBehaviour {
  public bool isGrounded = false;

  void OnCollisionStay2D (Collision2D coll) {
    if (coll.gameObject.tag == "Floor") {
      isGrounded = true;
    }
  }

  void OnCollisionExit2D (Collision2D coll) {
    if (coll.gameObject.tag == "Floor") {
      isGrounded = false;
    }
  }
}