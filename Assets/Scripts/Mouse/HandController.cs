using System;
using UnityEngine;

public class HandController : MonoBehaviour {

  public float maxSpeed;

  public bool isShaking;
  private float shakeAmount = 5f;
  private float shakeAngle = 0f;

  public bool isWobbling;
  private float wobbleAmountDelta = 0.2f;
  private float wobbleAmount = 0f;
  private float wobbleAmountMax = 2f;
  private float wobble = 0f;
  private float wobbleMax = 4f;

  private Vector2 GetMousePos() {
    return Camera.main.ScreenToWorldPoint(Input.mousePosition);
  }

  private void Move() {
    this.transform.position = Vector2.MoveTowards(
      this.transform.position,
      this.GetMousePos(),
      maxSpeed * Time.deltaTime
    );
  }

  private float RandomRange(float maxAngle) {
    return UnityEngine.Random.Range(-maxAngle, maxAngle);
  }

  private Vector2 AngleToVector(float angle) {
    return new Vector2((float) Math.Cos(angle), (float) Math.Sin(angle));
  }

  private void Shake() {
    this.shakeAngle += this.RandomRange((float) Math.PI / 2f);
    Vector2 dir = this.AngleToVector(shakeAngle);
    this.transform.position += (Vector3) dir * shakeAmount * Time.deltaTime;
  }

  private void Wobble() {
    Vector2 dir = (this.GetMousePos() - (Vector2) this.transform.position).normalized;
    dir = new Vector2(dir.y, dir.x);
    if(dir == Vector2.zero) {
      Shake();
    } else {
      this.wobbleAmount += this.RandomRange(this.wobbleAmountDelta);
      this.wobbleAmount = Mathf.Clamp(this.wobbleAmount, -this.wobbleAmountMax, this.wobbleAmountMax);
      this.wobble += this.RandomRange(this.wobbleAmount);
      this.wobble = Mathf.Clamp(this.wobble, -this.wobbleMax, this.wobbleMax);
      this.transform.position += (Vector3) dir * this.wobble * Time.deltaTime;
    }
  }

  public void Update() {
    Move();
    if(isShaking) {
      this.Shake();
    }
    if (isWobbling) {
      this.Wobble();
    }
  }
}
