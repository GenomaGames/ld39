using UnityEngine;

public class MenuController : MonoBehaviour {

  public void OnClickStart () {
    GameController.Instance.LoadNextScene();
  }
}
