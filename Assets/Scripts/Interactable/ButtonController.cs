using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour {

  public string id;
  public PromptController screen;

  public void Start() {
    screen = GameObject.Find("Screen").GetComponent<PromptController>();
  }

  public void OnMouseDown() {
    if(Config.DEBUG) {
      Debug.Log("Button " + id + " pressed");
    }
    if (screen != null) {
      screen.checkInteractable(id);
    }
  }
}
