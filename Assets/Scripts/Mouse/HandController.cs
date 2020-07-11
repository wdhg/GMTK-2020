using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandController : MonoBehaviour {

  public float maxSpeed;

  private bool isShaking = true;
  private float shakeAmount = 5f;
  private float shakeAngle = 0f;

  private void Move() {
    Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    this.transform.position = Vector2.MoveTowards(this.transform.position, mousePos, maxSpeed * Time.deltaTime);
  }

  private void Shake() {
    shakeAngle += UnityEngine.Random.Range((float) -Math.PI / 2f, (float) Math.PI / 2f);
    Vector2 dir = new Vector2((float) Math.Cos(shakeAngle), (float) Math.Sin(shakeAngle));
    this.transform.position += (Vector3) dir * shakeAmount * Time.deltaTime;
  }

  public void Update() {
    Move();
    if(isShaking) {
      this.Shake();
    }
  }
}
