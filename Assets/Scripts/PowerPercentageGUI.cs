using UnityEngine;
using UnityEngine.UI;

public class PowerPercentageGUI : MonoBehaviour {

  Power power;
  Text powerPercentageText;

  void Start () {
    GameObject playerGO = GameObject.FindGameObjectWithTag("Player");
    powerPercentageText = GetComponent<Text>();

    if (playerGO != null) {
      power = playerGO.GetComponent<Power>();
    }
  }

  void Update () {
    if (power != null) {
      powerPercentageText.text = power.powerPrecentage.ToString() + "%";
    }
  }
}
