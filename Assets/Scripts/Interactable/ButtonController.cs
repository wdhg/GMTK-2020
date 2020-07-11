using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ButtonController : MonoBehaviour {

  public string id;

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
  }

  private void Update() {
    if(this.handHovering && Input.GetKeyDown(KeyCode.Mouse0)) {
      if(Config.DEBUG) {
        Debug.Log("Button " + id + " pressed");
      }
    }
  }

}
