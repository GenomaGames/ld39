using UnityEngine;
using System;

public class Player : MonoBehaviour {

  public float thrust = 100;
  public float maxVelocity = 1;
  public float jumpForce = 5;
  public GroundCheck groundCheck;
  public string[] powerLoadInputSequence;
  public Transform respawnPosition;

  Rigidbody2D rb2d;
  Power power;
  string lastPowerLoadInput;
  Animator anim;


  void Start () {
    rb2d = GetComponent<Rigidbody2D>();
    power = GetComponent<Power>();
    anim = GetComponent<Animator>();

    try {
      lastPowerLoadInput = powerLoadInputSequence[0];
    } catch {
      Debug.LogError("You need to set at least 1 input on the Charge Input Sequence");
    }
  }
  
  // Update is called once per frame
  void Update () {;
    HandleInput();
  }

  void HandleInput () {
    float currVelocity = Mathf.Abs(rb2d.velocity.x);

    HandleInputChargeSequence();

    if (power.currentPower == 0) {
      return;
    }

    if (Input.GetAxis("Horizontal") != 0) {
      if (currVelocity < maxVelocity && groundCheck.isGrounded) {
        rb2d.AddRelativeForce(new Vector2(Input.GetAxis("Horizontal") * thrust * Time.deltaTime * 10, 0));

        if (transform.rotation.eulerAngles.z > 60 && transform.rotation.eulerAngles.z < 300) {
          Debug.Log("More torque" + transform.rotation.eulerAngles.z);
          rb2d.AddTorque(Input.GetAxis("Horizontal") * Time.deltaTime * 400);
        } else {
          rb2d.AddTorque(Input.GetAxis("Horizontal") * Time.deltaTime * 200);
        }

        power.Consume(10);
      }
    }

    if (Input.GetButtonDown("Jump") && groundCheck.isGrounded) {
      rb2d.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
      power.Consume(200);
    }
  }

  void HandleInputChargeSequence () {
    int nextPowerLoadInputIdx = System.Array.IndexOf(powerLoadInputSequence, lastPowerLoadInput) + 1;
    string nextPowerLoadInput = powerLoadInputSequence.Length == nextPowerLoadInputIdx ?  powerLoadInputSequence[0] : powerLoadInputSequence[nextPowerLoadInputIdx];
    
    for (int i = 0; i < powerLoadInputSequence.Length; i++) {
        if (Input.GetButtonDown(powerLoadInputSequence[i])) {

          if (powerLoadInputSequence[i] == nextPowerLoadInput) {
            power.Load();
            lastPowerLoadInput = nextPowerLoadInput;
          } else {
            power.Consume(100);
          }

          break;
        }
    }
  }

  public void Respawn () {
    rb2d.isKinematic = true;
    rb2d.velocity = Vector2.zero;
    rb2d.angularVelocity = 0;
    transform.rotation = Quaternion.identity;
    transform.position = respawnPosition.position;
    rb2d.isKinematic = false;
  }
}
