using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour {

  public string id;

  public void OnMouseDown() {
    if(Config.DEBUG) {
      Debug.Log("Button " + id + " pressed");
    }
  }
}
