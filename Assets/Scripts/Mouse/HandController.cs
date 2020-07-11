using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class HandController : MonoBehaviour {

  public float maxSpeed;

  private void Move() {
    Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    this.transform.position = Vector2.MoveTowards(this.transform.position, mousePos, maxSpeed * Time.deltaTime);
  }

  public void Update() {
    Move();
  }
}
