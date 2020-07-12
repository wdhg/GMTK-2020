using System.Threading;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour {

  public TextMeshProUGUI timerText;

  private float time;

  private void Update() {
    if(Input.GetKeyDown(KeyCode.Escape)) {
      Application.Quit();
    }
    time += Time.deltaTime;
    timerText.text = "Timer - " + (Mathf.Round(time * 100) / 100).ToString();
  }
}
