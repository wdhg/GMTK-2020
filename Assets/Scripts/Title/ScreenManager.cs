using UnityEngine;
using UnityEngine.SceneManagement;

public enum Screen {
  Main,
  HowToPlay,
  Credits,
  Play,
}

public class ScreenManager : MonoBehaviour {

  public GameObject mainScreen;
  public GameObject howToPlayScreen;
  public GameObject creditsScreen;

  private GameObject activeScreen;

  private void Start() {
    activeScreen = mainScreen;
  }

  public void OpenScreen(Screen screen) {
    activeScreen.SetActive(false);
    switch(screen) {
      case Screen.Main:
        activeScreen = mainScreen;
        break;
      case Screen.HowToPlay:
        activeScreen = howToPlayScreen;
        break;
      case Screen.Credits:
        activeScreen = creditsScreen;
        break;
      case Screen.Play:
        SceneManager.LoadScene(0); // TODO change this number to final Main scene number
        return;
    }
    activeScreen.SetActive(true);
  }
}
