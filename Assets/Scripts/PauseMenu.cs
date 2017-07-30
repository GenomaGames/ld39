using UnityEngine;

public class PauseMenu : MonoBehaviour {

  public void OnClickResume () {
    GameController.Instance.TogglePause();
  }

  public void OnClickRestart () {
    GameObject playerGO = GameObject.FindGameObjectWithTag("Player");

    if (playerGO != null) {
      playerGO.GetComponent<Player>().Respawn();
      GameController.Instance.TogglePause();
    }
  }

  public void OnClickExit () {
    GameController.Instance.LoadScene("Menu");
  }
}
