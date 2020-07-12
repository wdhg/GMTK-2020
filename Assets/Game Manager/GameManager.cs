using System.Threading;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

  public TextMeshProUGUI timerText;
  public GameObject ui, gameOver;
  public Meter sanity, work;
  public Text timeText;

  private float time;
  private bool isGameOver;

  private void Update() {
    if(Input.GetKeyDown(KeyCode.Escape)) {
      Application.Quit();
    }
    if (isGameOver) {
      if (Input.anyKeyDown) {
        SceneManager.LoadScene(1); // TODO set final scene number here
      }
    } else {
      time += Time.deltaTime;
      timerText.text = "Timer - " + (Mathf.Round(time * 100) / 100).ToString();
      if(sanity.currentValue <= 0 || work.currentValue <= 0) {
        ui.SetActive(false);
        gameOver.SetActive(true);
        timeText.text = "You lasted " + (Mathf.Round(time * 100) / 100).ToString() + "s";
        this.isGameOver = true;
      }
    }
  }
}
