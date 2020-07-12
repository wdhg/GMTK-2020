using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ButtonController : MonoBehaviour {

  public string id;
  public PromptController screen;
  public Transform sprite;
  public Vector3 home;
  public Vector3 animated;
  public float timer = 0.0f;
  public float buttonPressTime = 0.2f;
  bool animating;

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
  }

  private void Update() {
    if(this.handHovering && Input.GetKeyDown(KeyCode.Mouse0)) {
      if(Config.DEBUG) {
        Debug.Log("Button " + id + " pressed");
      }
      animateClicked();
      if (screen != null) {
        screen.checkInteractable(id);
      }
    }
    if (animating) {
      timer += Time.deltaTime;
      if (timer >= buttonPressTime) {
        endAnimation();
      }
    }
  }
  
  private void animateClicked() {
    if (Config.DEBUG) {
      Debug.Log("Animating " + id);
    }
    switch (id) {
      case "red_circle":
      case "yellow_circle":
        sprite = transform.Find("Button Body");
        if (sprite != null) {
            sprite.localPosition = new Vector3(0, -0.4f, 0);
            timer = 0.0f;
            animating = true;
        }
        break;
      case "red_square":
      case "green_square":
      case "blue_square":
        sprite = transform.Find("Button Body");
        if (sprite != null) {
            sprite.localPosition = new Vector3(0, -0.2f, 0);
            timer = 0.0f;
            animating = true;
        }
        break;
      //case "lever":
      case "slider_0":
        sprite = GameObject.Find("Handle").GetComponent<Transform>();
        if (sprite != null) {
          sprite.localPosition = new Vector3(-0.2362f, 0.5f, 0);
        }
        break;
      case "slider_1":
        sprite = GameObject.Find("Handle").GetComponent<Transform>();
        if (sprite != null) {
          sprite.localPosition = new Vector3(-0.121f, 0.5f, 0);
        }
        break;
      case "slider_2":
        sprite = GameObject.Find("Handle").GetComponent<Transform>();
        if (sprite != null) {
          sprite.localPosition = new Vector3(-0.0071f, 0.5f, 0);
        }
        break;
      case "slider_3":
        sprite = GameObject.Find("Handle").GetComponent<Transform>();
        if (sprite != null) {
          sprite.localPosition = new Vector3(0.1063f, 0.5f, 0);
        }
        break;
      case "slider_4":
        sprite = GameObject.Find("Handle").GetComponent<Transform>();
        if (sprite != null) {
          sprite.localPosition = new Vector3(0.2242f, 0.5f, 0);
        }
        break;
      case "lever":
        if (transform.localPosition == new Vector3 (3.8f, 4.218f, 0)) {
          transform.localPosition = new Vector3 (3.8f, 2.814f, 0);
          transform.Rotate(new Vector3 (0, 0, 90), Space.World);
        } else {
          transform.localPosition = new Vector3 (3.8f, 4.218f, 0);
          transform.Rotate(new Vector3 (0, 0, -90), Space.World);
        }
        break;
      default:
        break;
    }
  }

  private void endAnimation() {
      switch (id) {
        case "red_circle":
        case "yellow_circle":
        case "red_square":
        case "green_square":
        case "blue_square":
          sprite = transform.Find("Button Body");
          if (sprite != null) {
              sprite.transform.localPosition = new Vector3(0, 0, 0);
              timer = 0.0f;
              animating = false;
          }
          break;
        default:
          break;
      }
  }

}
