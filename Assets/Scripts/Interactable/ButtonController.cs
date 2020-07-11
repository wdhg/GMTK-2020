using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ButtonController : MonoBehaviour {

  public string id;
  public PromptController screen;

  public void Start() {
    screen = GameObject.Find("Screen").GetComponent<PromptController>();
  }

  bool handHovering = false;

  private void OnTriggerEnter2D(Collider2D collision) {
    if(collision.tag == "Hand") {
      this.handHovering = true;
    }
  }

  private void OnTriggerExit2D(Collider2D collision) {
    if(collision.tag == "Hand") {
      this.handHovering = false;
    }
    if (screen != null) {
      screen.checkInteractable(id);
    }
  }

  private void Update() {
    if(this.handHovering && Input.GetKeyDown(KeyCode.Mouse0)) {
      if(Config.DEBUG) {
        Debug.Log("Button " + id + " pressed");
      }
    }
  }

}
