using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : Singleton<GameController> {

  public bool gamePaused = false;
  public bool inGame = false;

  GameObject playerGO;
  Player player;
  GameObject pauseMenuGO;

  void Awake () {
    if (GameController.Instance == this) {
      DontDestroyOnLoad(this);
    }
  }

  void Start () {
    playerGO = GameObject.FindGameObjectWithTag("Player");
    
    if (playerGO != null) {
      player = playerGO.GetComponent<Player>();
    }

    SceneManager.sceneLoaded += OnSceneLoaded;
    OnSceneLoaded();
    
  }

  void Update () {

    if (inGame && Input.GetButtonDown("Cancel")) {
      TogglePause();
    }


    if (Input.GetKeyDown(KeyCode.R)) {
      player.Respawn();
    }

  }

  public void TogglePause () {
    gamePaused = !gamePaused;

    if (pauseMenuGO != null) {
      pauseMenuGO.SetActive(gamePaused);
    } else {
      Debug.Log("No pause menu found");
    }
  }

  public void LoadScene (string sceneName) {
    SceneManager.LoadScene(sceneName);
  }

  public void LoadNextScene () {
    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
  }

  void OnSceneLoaded (Scene scene, LoadSceneMode loadMode) {
    OnSceneLoaded();
  }

  void OnSceneLoaded () {
    inGame = SceneManager.GetActiveScene().name.Contains("Game");

    if (inGame) {
      pauseMenuGO = GameObject.FindGameObjectWithTag("PauseMenu");
      pauseMenuGO.SetActive(false);
    } else {
      pauseMenuGO = null;
    }
  }

}